// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using NewRelic.Agent.Configuration;
using NewRelic.Agent.Core.Aggregators;
using NewRelic.Agent.Core.Errors;
using NewRelic.Agent.Core.Time;
using NewRelic.Agent.Core.Transactions;
using NewRelic.Agent.Core.Wrapper.AgentWrapperApi.Builders;
using NewRelic.Agent.Core.Wrapper.AgentWrapperApi.Data;
using NewRelic.Testing.Assertions;
using NUnit.Framework;
using Telerik.JustMock;
using NewRelic.Agent.Core.CallStack;
using NewRelic.Agent.Core.Database;
using NewRelic.Agent.Core.Attributes;
using NewRelic.Agent.Core.Segments;
using NewRelic.Agent.Core.DistributedTracing;
using NewRelic.Agent.Core.Segments.Tests;
using NewRelic.Agent.TestUtilities;
using NewRelic.Agent.Core.Utilities;
using NewRelic.Agent.Api.Experimental;

namespace NewRelic.Agent.Core.Transformers.TransactionTransformer.UnitTest
{
    [TestFixture]
    public class ErrorEventMakerTests
    {
        private IConfiguration _configuration;
        private IConfigurationService _configurationService;
        private IErrorEventMaker _errorEventMaker;
        private ITransactionMetricNameMaker _transactionMetricNameMaker;
        private ISegmentTreeMaker _segmentTreeMaker;
        private ITransactionAttributeMaker _transactionAttributeMaker;
        private IErrorService _errorService;
        private static ISimpleTimerFactory _timerFactory;
        private IAttributeDefinitionService _attribDefSvc;
        private IAttributeDefinitions _attribDefs => _attribDefSvc?.AttributeDefs;
        private Func<IReadOnlyDictionary<string, object>, string> _errorGroupCallback;
        private IAgentTimerService _agentTimerService;
        private OutOfMemoryException _exception;
        private const string _expectedErrorGroupAttributeName = "error.group.name";
        private const string ErrorDataCustomAttributeKey = "myAttribute";

        [SetUp]
        public void SetUp()
        {
            _errorGroupCallback = null;
            _configuration = Mock.Create<IConfiguration>();

            _attribDefSvc = new AttributeDefinitionService((f) => new AttributeDefinitions(f));

            Mock.Arrange(() => _configuration.ErrorCollectorEnabled).Returns(true);
            Mock.Arrange(() => _configuration.ErrorCollectorCaptureEvents).Returns(true);
            Mock.Arrange(() => _configuration.ErrorGroupCallback).Returns(() => _errorGroupCallback);
            Mock.Arrange(() => _configuration.StackTraceMaximumFrames).Returns(() => 1);

            _configurationService = Mock.Create<IConfigurationService>();
            Mock.Arrange(() => _configurationService.Configuration).Returns(_configuration);

            _transactionMetricNameMaker = Mock.Create<ITransactionMetricNameMaker>();
            Mock.Arrange(() => _transactionMetricNameMaker.GetTransactionMetricName(Arg.IsAny<ITransactionName>()))
                .Returns(new TransactionMetricName("WebTransaction", "TransactionName"));

            _segmentTreeMaker = Mock.Create<ISegmentTreeMaker>();
            Mock.Arrange(() => _segmentTreeMaker.BuildSegmentTrees(Arg.IsAny<IEnumerable<Segment>>()))
                .Returns(new[] { BuildNode() });
            _agentTimerService = Mock.Create<IAgentTimerService>();
            _errorEventMaker = new ErrorEventMaker(_attribDefSvc, _configurationService, _agentTimerService);

            _timerFactory = new SimpleTimerFactory();

            _transactionAttributeMaker = new TransactionAttributeMaker(_configurationService, _attribDefSvc);
            _errorService = new ErrorService(_configurationService);

            _exception = new OutOfMemoryException("Out of Memory Message");
        }

        [TearDown]
        public void TearDown()
        {
            _attribDefSvc.Dispose();
        }

        private ErrorData GetErrorDataFromException(object value)
        {
            Dictionary<string, object> customAttributes = null;
            if (value != null)
            {
                customAttributes = new Dictionary<string, object> { { ErrorDataCustomAttributeKey, value } };
            }

            return _errorService.FromException(_exception, customAttributes);
        }

        private ErrorData GetErrorDataFromMessage(object value)
        {
            Dictionary<string, object> customAttributes = null;
            if (value != null)
            {
                customAttributes = new Dictionary<string, object> { { ErrorDataCustomAttributeKey, value } };
            }

            return _errorService.FromMessage("Out of Memory Message", customAttributes, false);
        } 

        [Test]
        public void GetErrorEvent_InTransaction_IfStatusCodeIs404_ContainsCorrectAttributes()
        {
            var transaction = BuildTestTransaction(statusCode: 404, uri: "http://www.newrelic.com/test?param=value", isSynthetics: false, isCAT: false, referrerUri: "http://referrer.uri");
            var immutableTransaction = transaction.ConvertToImmutableTransaction();

            var errorData = transaction.TransactionMetadata.TransactionErrorState.ErrorData;
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);

            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15), txStats);

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);

            var intrinsicAttributes = errorEvent.IntrinsicAttributes().Keys.ToArray();
            var agentAttributes = errorEvent.AgentAttributes().Keys.ToArray();
            var userAttributes = errorEvent.UserAttributes().Keys.ToArray();

            NrAssert.Multiple(
                () => Assert.That(errorEvent.IsSynthetics, Is.EqualTo(false)),
                () => Assert.That(agentAttributes, Has.Length.EqualTo(7)),
                () => Assert.That(intrinsicAttributes, Has.Length.EqualTo(8)),
                () => Assert.That(userAttributes, Is.Empty),

                () => Assert.That(agentAttributes, Does.Contain("queue_wait_time_ms")),
                () => Assert.That(agentAttributes, Does.Contain("response.status")),
                () => Assert.That(agentAttributes, Does.Contain("http.statusCode")),
                () => Assert.That(agentAttributes, Does.Contain("original_url")),
                () => Assert.That(agentAttributes, Does.Contain("request.uri")),
                () => Assert.That(agentAttributes, Does.Contain("request.referer")),
                () => Assert.That(agentAttributes, Does.Contain("host.displayName")),

                () => Assert.That(intrinsicAttributes, Does.Contain("duration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.class")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.message")),
                () => Assert.That(intrinsicAttributes, Does.Contain("queueDuration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("transactionName")),
                () => Assert.That(intrinsicAttributes, Does.Contain("guid")),
                () => Assert.That(intrinsicAttributes, Does.Contain("timestamp")),
                () => Assert.That(intrinsicAttributes, Does.Contain("type"))
            );
        }

        [Test]
        public void GetErrorEvent_InTransaction_WithException_ContainsCorrectAttributes()
        {
            var transaction = BuildTestTransaction(statusCode: 404, uri: "http://www.newrelic.com/test?param=value", isSynthetics: false, isCAT: false, referrerUri: "http://referrer.uri");
            transaction.NoticeError(_exception);
            var immutableTransaction = transaction.ConvertToImmutableTransaction();

            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);

            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);

            var intrinsicAttributes = errorEvent.IntrinsicAttributes().Keys.ToArray();
            var agentAttributes = errorEvent.AgentAttributes().Keys.ToArray();
            var userAttributes = errorEvent.UserAttributes().Keys.ToArray();

            NrAssert.Multiple(
                () => Assert.That(errorEvent.IsSynthetics, Is.EqualTo(false)),
                () => Assert.That(agentAttributes, Has.Length.EqualTo(7)),
                () => Assert.That(intrinsicAttributes, Has.Length.EqualTo(8)),
                () => Assert.That(userAttributes, Is.Empty),

                () => Assert.That(agentAttributes, Does.Contain("queue_wait_time_ms")),
                () => Assert.That(agentAttributes, Does.Contain("response.status")),
                () => Assert.That(agentAttributes, Does.Contain("original_url")),
                () => Assert.That(agentAttributes, Does.Contain("request.uri")),
                () => Assert.That(agentAttributes, Does.Contain("http.statusCode")),
                () => Assert.That(agentAttributes, Does.Contain("request.referer")),
                () => Assert.That(agentAttributes, Does.Contain("host.displayName")),

                () => Assert.That(intrinsicAttributes, Does.Contain("duration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.class")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.message")),
                () => Assert.That(intrinsicAttributes, Does.Contain("queueDuration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("transactionName")),
                () => Assert.That(intrinsicAttributes, Does.Contain("guid")),
                () => Assert.That(intrinsicAttributes, Does.Contain("timestamp")),
                () => Assert.That(intrinsicAttributes, Does.Contain("type"))
            );
        }

        [Test]
        public void GetErrorEvent_InTransaction_WithException_ContainsCorrectAttributes_FullAttributes()
        {
            var errorData = GetErrorDataFromException(null);
            var transaction = BuildTestTransaction(statusCode: 404,
                                                            customErrorData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();

            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);

            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);

            
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);

            var intrinsicAttributes = errorEvent.IntrinsicAttributes().Keys.ToArray();
            var agentAttributes = errorEvent.AgentAttributes().Keys.ToArray();
            var userAttributes = errorEvent.UserAttributes().Keys.ToArray();

            NrAssert.Multiple(
                () => Assert.That(errorEvent.IsSynthetics, Is.EqualTo(true)),

                () => Assert.That(agentAttributes, Has.Length.EqualTo(7)),
                () => Assert.That(intrinsicAttributes, Has.Length.EqualTo(17)),
                () => Assert.That(userAttributes, Has.Length.EqualTo(1)),

                () => Assert.That(agentAttributes, Does.Contain("queue_wait_time_ms")),
                () => Assert.That(agentAttributes, Does.Contain("response.status")),
                () => Assert.That(agentAttributes, Does.Contain("http.statusCode")),
                () => Assert.That(agentAttributes, Does.Contain("original_url")),
                () => Assert.That(agentAttributes, Does.Contain("request.uri")),
                () => Assert.That(agentAttributes, Does.Contain("request.referer")),
                () => Assert.That(agentAttributes, Does.Contain("host.displayName")),

                () => Assert.That(intrinsicAttributes, Does.Contain("duration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.class")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.message")),
                () => Assert.That(intrinsicAttributes, Does.Contain("queueDuration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("transactionName")),
                () => Assert.That(intrinsicAttributes, Does.Contain("guid")),
                () => Assert.That(intrinsicAttributes, Does.Contain("timestamp")),
                () => Assert.That(intrinsicAttributes, Does.Contain("type")),
                () => Assert.That(intrinsicAttributes, Does.Contain("nr.syntheticsJobId")),
                () => Assert.That(intrinsicAttributes, Does.Contain("nr.syntheticsResourceId")),
                () => Assert.That(intrinsicAttributes, Does.Contain("nr.syntheticsMonitorId")),
                () => Assert.That(intrinsicAttributes, Does.Contain("nr.referringTransactionGuid")),
                () => Assert.That(intrinsicAttributes, Does.Contain("databaseDuration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("databaseCallCount")),
                () => Assert.That(intrinsicAttributes, Does.Contain("externalDuration")),
                () => Assert.That(intrinsicAttributes, Does.Contain("externalCallCount")),
                () => Assert.That(intrinsicAttributes, Does.Contain("nr.guid")),

                () => Assert.That(userAttributes, Does.Contain("sample.user.attribute"))
            );
        }

        [Test]
        public void GetErrorEvent_NoTransaction_WithException_ContainsCorrectAttributes()
        {
            // Arrange
            var customAttributes = new AttributeValueCollection(AttributeDestinations.ErrorEvent);
            var errorData = GetErrorDataFromException(null);
            _attribDefs.GetCustomAttributeForError("custom attribute name").TrySetValue(customAttributes, "custom attribute value");

            // Act
            float priority = 0.5f;
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, customAttributes, priority);

            var agentAttributes = errorEvent.AgentAttributes().Keys.ToArray();
            var intrinsicAttributes = errorEvent.IntrinsicAttributes().Keys.ToArray();
            var userAttributes = errorEvent.UserAttributes().Keys.ToArray();

            // Assert
            NrAssert.Multiple(
                () => Assert.That(errorEvent.IsSynthetics, Is.EqualTo(false)),
                () => Assert.That(agentAttributes, Is.Empty),
                () => Assert.That(intrinsicAttributes, Has.Length.EqualTo(4)),
                () => Assert.That(userAttributes, Has.Length.EqualTo(1)),

                () => Assert.That(intrinsicAttributes, Does.Contain("error.class")),
                () => Assert.That(intrinsicAttributes, Does.Contain("error.message")),
                () => Assert.That(intrinsicAttributes, Does.Contain("timestamp")),
                () => Assert.That(intrinsicAttributes, Does.Contain("type")),

                () => Assert.That(userAttributes, Does.Contain("custom attribute name"))
            );
        }

        #region ErrorGroup FromMesssage

        [TestCase("value")]
        [TestCase(null)]
        public void GetErrorEvent_NoTransaction_FromMessage_ContainsErrorGroup(object value)
        {
            _errorGroupCallback = ex => "test group";
            var errorData = GetErrorDataFromMessage(value);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributes = errorEvent.AgentAttributes();
            var errorGroupAttribute = agentAttributes[_expectedErrorGroupAttributeName];

            Assert.That(errorGroupAttribute, Is.EqualTo("test group"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void GetErrorEvent_NoTransaction_FromMessage_DoesNotContainErrorGroup(string callbackReturnValue)
        {
            _errorGroupCallback = ex => callbackReturnValue;
            var errorData = GetErrorDataFromMessage(null);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        [Test]
        public void GetErrorEvent_NoTransaction_FromMessage_DoesNotContainErrorGroup()
        {
            var errorData = GetErrorDataFromMessage(null);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;
            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        [TestCase("value")]
        [TestCase(null)]
        public void GetErrorEvent_InTransaction_FromMessage_ContainsErrorGroup(object value)
        {
            _errorGroupCallback = ex => "test group";
            var errorData = GetErrorDataFromMessage(value);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributes = errorEvent.AgentAttributes();
            var errorGroupAttribute = agentAttributes[_expectedErrorGroupAttributeName];

            Assert.That(errorGroupAttribute, Is.EqualTo("test group"));
        }

        [Test]
        public void GetErrorEvent_InTransaction_FromMessage_DoesNotContainErrorGroup()
        {
            var errorData = GetErrorDataFromMessage(null);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member("error_group"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void GetErrorEvent_InTransaction_FromMessage_DoesNotContainErrorGroup(string errorGroupValue)
        {
            _errorGroupCallback = ex => errorGroupValue;
            var errorData = GetErrorDataFromMessage(null);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        #endregion

        #region ErrorGroup FromException

        [TestCase("value")]
        [TestCase(null)]
        public void GetErrorEvent_NoTransaction_FromException_ContainsErrorGroup(object value)
        {
            IReadOnlyDictionary<string, object> passedInDict = null;
            _errorGroupCallback = ex =>
            {
                passedInDict = ex;
                return "test group";
            };
            var errorData = GetErrorDataFromException(value);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributes = errorEvent.AgentAttributes();
            var errorGroupAttribute = agentAttributes[_expectedErrorGroupAttributeName];

            Assert.That(passedInDict, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(passedInDict.ContainsKey("stack_trace"), Is.True);
                Assert.That(passedInDict.ContainsKey("exception"), Is.True);
                Assert.That(errorGroupAttribute, Is.EqualTo("test group"));
            });
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void GetErrorEvent_NoTransaction_FromException_DoesNotContainErrorGroup(string callbackReturnValue)
        {
            _errorGroupCallback = ex => callbackReturnValue;
            var errorData = GetErrorDataFromException(null);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        [Test]
        public void GetErrorEvent_NoTransaction_FromException_DoesNotContainErrorGroup()
        {
            var errorData = GetErrorDataFromException(null);
            var errorEvent = _errorEventMaker.GetErrorEvent(errorData, new AttributeValueCollection(AttributeDestinations.ErrorEvent), 0.5f);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;
            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        [TestCase("value")]
        [TestCase(null)]
        public void GetErrorEvent_InTransaction_FromException_ContainsErrorGroup(object value)
        {
            IReadOnlyDictionary<string, object> passedInDict = null;
            _errorGroupCallback = ex =>
            {
                passedInDict = ex;
                return "test group";
            };
            var errorData = GetErrorDataFromException(value);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributes = errorEvent.AgentAttributes();
            var errorGroupAttribute = agentAttributes[_expectedErrorGroupAttributeName];

            Assert.That(passedInDict, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(passedInDict.ContainsKey("stack_trace"), Is.True);
                Assert.That(passedInDict.ContainsKey("exception"), Is.True);
                Assert.That(errorGroupAttribute, Is.EqualTo("test group"));
            });
        }

        [Test]
        public void GetErrorEvent_InTransaction_FromException_DoesNotContainErrorGroup()
        {
            var errorData = GetErrorDataFromException(null);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member("error_group"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void GetErrorEvent_InTransaction_FromException_DoesNotContainErrorGroup(string errorGroupValue)
        {
            _errorGroupCallback = ex => errorGroupValue;
            var errorData = GetErrorDataFromException(null);
            var transaction = BuildTestTransaction(statusCode: 500,
                                                            exceptionData: errorData,
                                                            uri: "http://www.newrelic.com/test?param=value",
                                                            referrerUri: "http://referrer.uri",
                                                            includeUserAttributes: true);

            var immutableTransaction = transaction.ConvertToImmutableTransaction();
            var transactionMetricName = _transactionMetricNameMaker.GetTransactionMetricName(immutableTransaction.TransactionName);
            var txStats = new TransactionMetricStatsCollection(transactionMetricName);
            var attributes = _transactionAttributeMaker.GetAttributes(immutableTransaction, transactionMetricName, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15), txStats);
            attributes.AddRange(GetIntrinsicAttributes());

            var errorEvent = _errorEventMaker.GetErrorEvent(immutableTransaction, attributes);
            var agentAttributeKeys = errorEvent.AgentAttributes().Keys;

            Assert.That(agentAttributeKeys, Has.No.Member(_expectedErrorGroupAttributeName));
        }

        #endregion

        private IAttributeValueCollection GetIntrinsicAttributes()
        {
            var attributes = new AttributeValueCollection(AttributeDestinations.ErrorEvent);

            _attribDefs.DatabaseCallCount.TrySetValue(attributes, 10);
            _attribDefs.DatabaseDuration.TrySetValue(attributes, (float)TimeSpan.FromSeconds(10).TotalSeconds);
            _attribDefs.ExternalCallCount.TrySetValue(attributes, 10);
            _attribDefs.ExternalDuration.TrySetValue(attributes, (float)TimeSpan.FromSeconds(10).TotalSeconds);

            return attributes;
        }

        private IInternalTransaction BuildTestTransaction(bool isWebTransaction = true, string uri = null, string referrerUri = null, string guid = null, int? statusCode = null, int? subStatusCode = null, string referrerCrossProcessId = null, string transactionCategory = "defaultTxCategory", string transactionName = "defaultTxName", ErrorData exceptionData = null, ErrorData customErrorData = null, bool isSynthetics = true, bool isCAT = true, bool includeUserAttributes = false)
        {
            var name = isWebTransaction
                ? TransactionName.ForWebTransaction(transactionCategory, transactionName)
                : TransactionName.ForOtherTransaction(transactionCategory, transactionName);

            var segments = Enumerable.Empty<Segment>();

            var placeholderMetadataBuilder = new TransactionMetadata(guid);
            var placeholderMetadata = placeholderMetadataBuilder.ConvertToImmutableMetadata();

            var attribDefSvc = new AttributeDefinitionService((f) => new AttributeDefinitions(f));

            var immutableTransaction = new ImmutableTransaction(name, segments, placeholderMetadata, DateTime.Now, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10), guid, false, false, false, 0.5f, false, string.Empty, null, attribDefSvc.AttributeDefs);

            var priority = 0.5f;
            var internalTransaction = new Transaction(Mock.Create<IConfiguration>(), immutableTransaction.TransactionName, _timerFactory.StartNewTimer(), DateTime.UtcNow, Mock.Create<ICallStackManager>(), Mock.Create<IDatabaseService>(), priority, Mock.Create<IDatabaseStatementParser>(), Mock.Create<IDistributedTracePayloadHandler>(), _errorService, _attribDefSvc.AttributeDefs);
            var transactionMetadata = internalTransaction.TransactionMetadata;
            PopulateTransactionMetadataBuilder(internalTransaction, uri, statusCode, subStatusCode, referrerCrossProcessId, exceptionData, customErrorData, isSynthetics, isCAT, referrerUri, includeUserAttributes);

            return internalTransaction;
        }

        private void PopulateTransactionMetadataBuilder(IInternalTransaction transaction, string uri = null, int? statusCode = null, int? subStatusCode = null, string referrerCrossProcessId = null, ErrorData exceptionData = null, ErrorData customErrorData = null, bool isSynthetics = true, bool isCAT = true, string referrerUri = null, bool includeUserAttributes = false)
        {
            var metadata = transaction.TransactionMetadata;

            if (uri != null)
                metadata.SetUri(uri);
            if (statusCode != null)
                metadata.SetHttpResponseStatusCode(statusCode.Value, subStatusCode, _errorService);
            if (referrerCrossProcessId != null)
                metadata.SetCrossApplicationReferrerProcessId(referrerCrossProcessId);
            if (statusCode != null)
                metadata.SetHttpResponseStatusCode(statusCode.Value, subStatusCode, _errorService);
            if (exceptionData != null)
                metadata.TransactionErrorState.AddExceptionData(exceptionData);
            if (customErrorData != null)
                metadata.TransactionErrorState.AddCustomErrorData(customErrorData);
            if (referrerUri != null)
                metadata.SetReferrerUri(referrerUri);
            if (isCAT)
            {
                metadata.SetCrossApplicationReferrerProcessId("cross application process id");
                metadata.SetCrossApplicationReferrerTransactionGuid("transaction Guid");
            }

            metadata.SetQueueTime(TimeSpan.FromSeconds(10));
            metadata.SetOriginalUri("originalUri");
            metadata.SetCrossApplicationPathHash("crossApplicationPathHash");
            metadata.SetCrossApplicationReferrerContentLength(10000);
            metadata.SetCrossApplicationReferrerPathHash("crossApplicationReferrerPathHash");
            metadata.SetCrossApplicationReferrerTripId("crossApplicationReferrerTripId");

            if (includeUserAttributes)
            {
                transaction.AddCustomAttribute("sample.user.attribute", "user attribute string");
            }

            if (isSynthetics)
            {
                metadata.SetSyntheticsResourceId("syntheticsResourceId");
                metadata.SetSyntheticsJobId("syntheticsJobId");
                metadata.SetSyntheticsMonitorId("syntheticsMonitorId");
            }
        }

        private static ImmutableSegmentTreeNode BuildNode(TimeSpan relativeStart = new TimeSpan(), TimeSpan? duration = null)
        {
            var methodCallData = new MethodCallData("typeName", "methodName", 1);
            var segment = new Segment(TransactionSegmentStateHelpers.GetItransactionSegmentState(), methodCallData);
            segment.SetSegmentData(new SimpleSegmentData(""));

            return new SegmentTreeNodeBuilder(
                new Segment(relativeStart, duration ?? TimeSpan.Zero, segment, null))
                .Build();
        }

    }
}
