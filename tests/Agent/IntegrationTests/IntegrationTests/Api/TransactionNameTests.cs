// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0


using System.Linq;
using NewRelic.Agent.IntegrationTestHelpers;
using NewRelic.Agent.IntegrationTestHelpers.RemoteServiceFixtures;
using Xunit;

namespace NewRelic.Agent.IntegrationTests.Api
{
    public abstract class TransactionNameTests<TFixture> : NewRelicIntegrationTest<TFixture> where TFixture : ConsoleDynamicMethodFixture
    {
        protected readonly TFixture Fixture;

        public TransactionNameTests(TFixture fixture, ITestOutputHelper output) : base(fixture)
        {
            Fixture = fixture;
            Fixture.TestLogger = output;

            Fixture.AddCommand("ApiCalls TestSetTransactionName TestGroup OriginalName,NewName");

            Fixture.Actions
            (
                setupConfiguration: () =>
                {
                    var configModifier = new NewRelicConfigModifier(Fixture.DestinationNewRelicConfigFilePath);
                    configModifier.SetOrDeleteDistributedTraceEnabled(true);
                    configModifier.SetLogLevel("finest");
                    configModifier.DisableEventListenerSamplers(); // Required for .NET 8 to pass.
                }
            );

            Fixture.Initialize();
        }

        [Fact]
        public void TestSetTransactionName()
        {
            var setNameLines = Fixture.AgentLog.TryGetLogLines(AgentLogBase.TransactionLinePrefix + "Setting transaction name to.*?");
            Assert.Equal(2, setNameLines.Count());

            Assert.NotNull(Fixture.AgentLog.TryGetTransactionEvent("OtherTransaction/TestGroup/NewName"));
            Assert.Null(Fixture.AgentLog.TryGetTransactionEvent("OtherTransaction/TestGroup/OriginalName"));

            // Note the trailing space is necessary here, or we'll find "Ignoring transaction_segment_term with invalid prefix" which is unrelated
            var notConnectedLogLine = Fixture.AgentLog.TryGetLogLine(AgentLogBase.TransactionLinePrefix + "Ignoring transaction name ");
            Assert.Null(notConnectedLogLine);

        }
    }

    public class TransactionNameTestsFW : TransactionNameTests<ConsoleDynamicMethodFixtureFWLatest>
    {
        public TransactionNameTestsFW(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
        }
    }

    public class TransactionNameTestsCore : TransactionNameTests<ConsoleDynamicMethodFixtureCoreLatest>
    {
        public TransactionNameTestsCore(ConsoleDynamicMethodFixtureCoreLatest fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
        }
    }
}
