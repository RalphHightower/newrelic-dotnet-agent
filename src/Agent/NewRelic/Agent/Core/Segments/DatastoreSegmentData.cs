// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using NewRelic.Agent.Api.Experimental;
using NewRelic.Agent.Configuration;
using NewRelic.Agent.Core.Aggregators;
using NewRelic.Agent.Core.Attributes;
using NewRelic.Agent.Core.Database;
using NewRelic.Agent.Core.Metrics;
using NewRelic.Agent.Core.Spans;
using NewRelic.Agent.Core.Time;
using NewRelic.Agent.Core.Transactions;
using NewRelic.Agent.Core.WireModels;
using NewRelic.Agent.Extensions.Parsing;
using NewRelic.Agent.Extensions.Providers.Wrapper;
using NewRelic.Agent.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using NewRelic.Agent.Extensions.Collections;
using static NewRelic.Agent.Core.WireModels.MetricWireModel;

namespace NewRelic.Agent.Core.Segments
{
    public class DatastoreSegmentData : AbstractSegmentData, IDatastoreSegmentData
    {
        private readonly static ConnectionInfo EmptyConnectionInfo = new ConnectionInfo(null, null, null, null);

        public override SpanCategory SpanCategory => SpanCategory.Datastore;

        public string Operation => _parsedSqlStatement.Operation;
        public DatastoreVendor DatastoreVendorName => _parsedSqlStatement.DatastoreVendor;
        public string Model => _parsedSqlStatement.Model;
        public string CommandText { get; set; }
        public string Host => _connectionInfo.Host;
        public int? Port => _connectionInfo.Port;
        public string PathOrId => _connectionInfo.PathOrId;
        public string PortPathOrId => _connectionInfo.PortPathOrId;
        public string DatabaseName => _connectionInfo.DatabaseName;
        public Func<object> GetExplainPlanResources { get; set; }
        public Func<object, ExplainPlan> GenerateExplainPlan { get; set; }
        public Func<bool> DoExplainPlanCondition { get; set; }

        public IDictionary<string, IConvertible> QueryParameters { get; set; }

        private object _explainPlanResources;
        private ExplainPlan _explainPlan;

        private ConnectionInfo _connectionInfo;
        private ParsedSqlStatement _parsedSqlStatement;

        public ExplainPlan ExplainPlan => _explainPlan;

        private readonly IDatabaseService _databaseService;
        private static CacheByDatastoreVendor<string, string> _failedExplainPlanQueryCacheByDatastoreVendor;

        static DatastoreSegmentData()
        {
            _failedExplainPlanQueryCacheByDatastoreVendor = new CacheByDatastoreVendor<string, string>("FailedExplainPlanQueryCache");
            _failedExplainPlanQueryCacheByDatastoreVendor.SetCapacity(1000);
        }

        public DatastoreSegmentData(IDatabaseService databaseService,
            ParsedSqlStatement parsedSqlStatement, string commandText = null, ConnectionInfo connectionInfo = null,
            IDictionary<string, IConvertible> queryParameters = null)
        {
            _databaseService = databaseService;
            _connectionInfo = connectionInfo ?? EmptyConnectionInfo;
            _parsedSqlStatement = parsedSqlStatement;
            CommandText = commandText;
            QueryParameters = queryParameters;
        }

        internal override void AddTransactionTraceParameters(IConfigurationService configurationService, Segment segment, IDictionary<string, object> segmentParameters, ImmutableTransaction immutableTransaction)
        {
            if (ExplainPlan != null)
            {
                segmentParameters["explain_plan"] = new ExplainPlanWireModel(ExplainPlan);
            }

            if (CommandText != null)
            {
                segmentParameters["sql"] = _databaseService.GetObfuscatedSql(CommandText, DatastoreVendorName);
            }

            if (configurationService.Configuration.InstanceReportingEnabled)
            {
                segmentParameters["host"] = Host;
                segmentParameters["port_path_or_id"] = PortPathOrId;
            }

            if (configurationService.Configuration.DatabaseNameReportingEnabled)
            {
                segmentParameters["database_name"] = DatabaseName;
            }

            if (QueryParameters != null)
            {
                segmentParameters["query_parameters"] = QueryParameters;
            }
        }

        internal override IEnumerable<KeyValuePair<string, object>> Finish()
        {
            if (GetExplainPlanResources == null)
                return null;

            // Ensures we aren't running explain plan twice
            if (_explainPlanResources != null)
                return null;

            try
            {
                // Using invoke for thread safety, DoExplainPlanCondition is nullable
                if (DoExplainPlanCondition?.Invoke() == true)
                {
                    _explainPlanResources = GetExplainPlanResources();
                }
                else
                {
                    GetExplainPlanResources = null;
                    GenerateExplainPlan = null;
                }
            }
            catch (Exception exception)
            {
                Log.Debug(exception, "Unable to retrieve resources for explain plan");
            }
            return null;
        }


        public bool ExecuteExplainPlan(SqlObfuscator obfuscator)
        {
            // don't attempt to generate an explain plan if this query has failed previously
            if (_failedExplainPlanQueryCacheByDatastoreVendor.Contains(DatastoreVendorName, CommandText))
                return false;

            // Don't re-run an explain plan if one already exists
            if (_explainPlan != null)
                return false;

            try
            {
                // Using invoke for thread safety, DoExplainPlanCondition is nullable
                if (DoExplainPlanCondition?.Invoke() == true)
                {
                    var explainPlan = GenerateExplainPlan?.Invoke(_explainPlanResources);
                    if (explainPlan != null)
                    {
                        foreach (var data in explainPlan.ExplainPlanDatas)
                        {
                            foreach (var index in explainPlan.ObfuscatedHeaders)
                            {
                                data[index] = obfuscator.GetObfuscatedSql(data[index].ToString(), DatastoreVendorName);
                            }
                        }

                        _explainPlan = new ExplainPlan(explainPlan.ExplainPlanHeaders, explainPlan.ExplainPlanDatas, explainPlan.ObfuscatedHeaders);
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Debug(exception, "Unable to execute explain plan for query: {Query}. This query will be ignored for future explain plan execution.",
                    obfuscator.GetObfuscatedSql(CommandText, DatastoreVendorName) ?? "[redacted]");
                _failedExplainPlanQueryCacheByDatastoreVendor.TryAdd(DatastoreVendorName, CommandText, () => string.Empty); // all we really want to cache is the query text
                return false;
            }
        }

        public override bool IsCombinableWith(AbstractSegmentData otherSegment)
        {

            var otherTypedSegment = otherSegment as DatastoreSegmentData;
            if (otherTypedSegment == null)
                return false;

            if (Operation != otherTypedSegment.Operation)
                return false;

            if (DatastoreVendorName != otherTypedSegment.DatastoreVendorName)
                return false;

            if (Model != otherTypedSegment.Model)
                return false;

            return true;
        }

        public override string GetTransactionTraceName()
        {
            var name = string.IsNullOrEmpty(Model) ? DatastoreVendorName.GetDatastoreOperation(Operation) : MetricNames.GetDatastoreStatement(DatastoreVendorName, Model, Operation);
            return name.ToString();
        }

        public override void AddMetricStats(Segment segment, TimeSpan durationOfChildren, TransactionMetricStatsCollection txStats, IConfigurationService configService)
        {
            var duration = segment.Duration.Value;
            var exclusiveDuration = TimeSpanMath.Max(TimeSpan.Zero, duration - durationOfChildren);

            if (!string.IsNullOrEmpty(Model))
            {
                MetricBuilder.TryBuildDatastoreStatementMetric(DatastoreVendorName, _parsedSqlStatement, duration, exclusiveDuration, txStats);
                MetricBuilder.TryBuildDatastoreVendorOperationMetric(DatastoreVendorName, Operation, duration, exclusiveDuration, txStats, true);
            }
            else
            {
                MetricBuilder.TryBuildDatastoreVendorOperationMetric(DatastoreVendorName, Operation, duration, exclusiveDuration, txStats, false);
            }

            MetricBuilder.TryBuildDatastoreRollupMetrics(DatastoreVendorName, duration, exclusiveDuration, txStats);

            if (configService.Configuration.InstanceReportingEnabled)
            {
                MetricBuilder.TryBuildDatastoreInstanceMetric(DatastoreVendorName, Host,
                PortPathOrId, duration, duration, txStats);
            }
        }

        private string GetObfuscatedSQL()
        {
            return _databaseService.GetObfuscatedSql(CommandText, DatastoreVendorName);
        }

        public override void SetSpanTypeSpecificAttributes(SpanAttributeValueCollection attribVals)
        {
            AttribDefs.SpanCategory.TrySetValue(attribVals, SpanCategory.Datastore);
            AttribDefs.Component.TrySetValue(attribVals, EnumNameCache<DatastoreVendor>.GetName(DatastoreVendorName));

            if (!string.IsNullOrWhiteSpace(CommandText))
            {
                AttribDefs.DbStatement.TrySetValue(attribVals, GetObfuscatedSQL());
            }

            if (!string.IsNullOrEmpty(_parsedSqlStatement.Model))
            {
                AttribDefs.DbCollection.TrySetValue(attribVals, _parsedSqlStatement.Model);
            }

            AttribDefs.DbSystem.TrySetValue(attribVals, DatastoreVendorName.ToKnownName());
            AttribDefs.DbInstance.TrySetValue(attribVals, DatabaseName);
            AttribDefs.DbOperation.TrySetValue(attribVals, Operation);
            AttribDefs.PeerAddress.TrySetValue(attribVals, $"{Host}:{PortPathOrId}");
            AttribDefs.SpanKind.TrySetDefault(attribVals);
            // peer.hostname and server.address must match
            AttribDefs.PeerHostname.TrySetValue(attribVals, Host);
            AttribDefs.DbServerAddress.TrySetValue(attribVals, Host);
            if (Port != null)
            {
                AttribDefs.DbServerPort.TrySetValue(attribVals, Port.Value);
            }
        }

        public void SetConnectionInfo(ConnectionInfo connInfo)
        {
            _connectionInfo = connInfo;
        }

        /// <summary>
        /// FOR UNIT TESTING ONLY
        /// </summary>
        public static void ClearFailedExplainPlanCache()
        {
            _failedExplainPlanQueryCacheByDatastoreVendor.Reset();
        }

        /// <summary>
        /// FOR UNIT TESTING ONLY
        /// </summary>
        public CacheByDatastoreVendor<string, string> GetFailedExplainPlanCache()
        {
            return _failedExplainPlanQueryCacheByDatastoreVendor;
        }
    }
}
