// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using NewRelic.Agent.IntegrationTestHelpers;
using NewRelic.Agent.IntegrationTests.RemoteServiceFixtures.AwsLambda;
using NewRelic.Agent.Tests.TestSerializationHelpers.Models;
using Xunit;

namespace NewRelic.Agent.IntegrationTests.AwsLambda.Ses
{
    public abstract class AwsLambdaSesEventTest<T> : NewRelicIntegrationTest<T> where T : LambdaSesEventTriggerFixtureBase
    {
        private readonly LambdaSesEventTriggerFixtureBase _fixture;
        private readonly string _expectedTransactionName;

        protected AwsLambdaSesEventTest(T fixture, ITestOutputHelper output, string expectedTransactionName)
            : base(fixture)
        {
            _expectedTransactionName = expectedTransactionName;

            _fixture = fixture;
            _fixture.TestLogger = output;
            _fixture.Actions(
                exerciseApplication: () =>
                {
                    _fixture.EnqueueEvent();
                    _fixture.AgentLog.WaitForLogLines(AgentLogBase.ServerlessPayloadLogLineRegex, TimeSpan.FromMinutes(1), 2);
                }
                );
            _fixture.Initialize();
        }

        [Fact]
        public void Test()
        {
            var serverlessPayloads = _fixture.AgentLog.GetServerlessPayloads().ToList();

            Assert.Multiple(
                () => Assert.Single(serverlessPayloads),
                () => ValidateServerlessPayload(serverlessPayloads[0]),
                () => Assert.All(serverlessPayloads, ValidateTraceHasNoParent)
                );
        }

        private void ValidateServerlessPayload(ServerlessPayload serverlessPayload)
        {
            var transactionEvent = serverlessPayload.Telemetry.TransactionEventsPayload.TransactionEvents.Single();

            var expectedAgentAttributes = new[]
            {
                "aws.lambda.arn",
                "aws.requestId"
            };

            var expectedAgentAttributeValues = new Dictionary<string, object>
            {
                { "aws.lambda.eventSource.eventType", "ses" },
                { "aws.lambda.eventSource.length", 1 },
                { "aws.lambda.eventSource.date", "Wed, 7 Oct 2015 12:34:56 -0700" },
                { "aws.lambda.eventSource.messageId", "<0123456789example.com>" },
                { "aws.lambda.eventSource.returnPath", "janedoe@example.com" }
            };

            Assert.Equal(_expectedTransactionName, transactionEvent.IntrinsicAttributes["name"]);

            Assertions.TransactionEventHasAttributes(expectedAgentAttributes, TransactionEventAttributeType.Agent, transactionEvent);
            Assertions.TransactionEventHasAttributes(expectedAgentAttributeValues, TransactionEventAttributeType.Agent, transactionEvent);
        }

        private void ValidateTraceHasNoParent(ServerlessPayload serverlessPayload)
        {
            var entrySpan = serverlessPayload.Telemetry.SpanEventsPayload.SpanEvents.Single(s => (string)s.IntrinsicAttributes["name"] == _expectedTransactionName);

            Assertions.SpanEventDoesNotHaveAttributes(["parentId"], SpanEventAttributeType.Intrinsic, entrySpan);
        }
    }

    public class AwsLambdaSesEventTestCoreOldest : AwsLambdaSesEventTest<LambdaSesEventTriggerFixtureCoreOldest>
    {
        public AwsLambdaSesEventTestCoreOldest(LambdaSesEventTriggerFixtureCoreOldest fixture, ITestOutputHelper output)
            : base(fixture, output, "OtherTransaction/Lambda/SesEvent")
        {
        }
    }

    public class AwsLambdaAsyncSesEventTestCoreOldest : AwsLambdaSesEventTest<AsyncLambdaSesEventTriggerFixtureCoreOldest>
    {
        public AwsLambdaAsyncSesEventTestCoreOldest(AsyncLambdaSesEventTriggerFixtureCoreOldest fixture, ITestOutputHelper output)
            : base(fixture, output, "OtherTransaction/Lambda/SesEventAsync")
        {
        }
    }

    public class AwsLambdaSesEventTestCoreLatest : AwsLambdaSesEventTest<LambdaSesEventTriggerFixtureCoreLatest>
    {
        public AwsLambdaSesEventTestCoreLatest(LambdaSesEventTriggerFixtureCoreLatest fixture, ITestOutputHelper output)
            : base(fixture, output, "OtherTransaction/Lambda/SesEvent")
        {
        }
    }

    public class AwsLambdaAsyncSesEventTestCoreLatest : AwsLambdaSesEventTest<AsyncLambdaSesEventTriggerFixtureCoreLatest>
    {
        public AwsLambdaAsyncSesEventTestCoreLatest(AsyncLambdaSesEventTriggerFixtureCoreLatest fixture, ITestOutputHelper output)
            : base(fixture, output, "OtherTransaction/Lambda/SesEventAsync")
        {
        }
    }
}
