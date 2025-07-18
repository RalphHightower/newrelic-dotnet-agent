// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using MoreLinq;
using NewRelic.Agent.Api.Experimental;
using NewRelic.Agent.Core.Attributes;
using NewRelic.Agent.Core.CallStack;
using NewRelic.Agent.Core.Database;
using NewRelic.Agent.Core.DistributedTracing;
using NewRelic.Agent.Core.Errors;
using NewRelic.Agent.Core.Time;
using NewRelic.Agent.Core.Wrapper.AgentWrapperApi.Builders;
using NewRelic.Agent.Extensions.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace NewRelic.Agent.Core.Transactions.UnitTest
{
    [TestFixture]
    public class TransactionBuilderServiceTests
    {
        private TransactionService _transactionService;
        private IContextStorage<IInternalTransaction> _lowPriorityTransactionContext;
        private IContextStorage<IInternalTransaction> _highPriorityTransactionContext;
        private readonly TransactionName _initialTransactionName = TransactionName.ForWebTransaction("initialCategory", "initialName");

        [SetUp]
        public void SetUp()
        {
            _lowPriorityTransactionContext = Mock.Create<IContextStorage<IInternalTransaction>>();
            Mock.Arrange(() => _lowPriorityTransactionContext.Priority).Returns(1);
            DictionaryTransactionContext(_lowPriorityTransactionContext);

            _highPriorityTransactionContext = Mock.Create<IContextStorage<IInternalTransaction>>();
            Mock.Arrange(() => _highPriorityTransactionContext.Priority).Returns(2);
            DictionaryTransactionContext(_highPriorityTransactionContext);

            var factory1 = CreateFactoryForTransactionContext(_highPriorityTransactionContext);
            var factory2 = CreateFactoryForTransactionContext(_lowPriorityTransactionContext);

            IAttributeDefinitionService _attribDefSvc = new AttributeDefinitionService((f) => new AttributeDefinitions(f));

            _transactionService = new TransactionService(new[] { factory1, factory2 }, Mock.Create<ISimpleTimerFactory>(), Mock.Create<ICallStackManagerFactory>(), Mock.Create<IDatabaseService>(), Mock.Create<ITracePriorityManager>(), Mock.Create<IDatabaseStatementParser>(), Mock.Create<IErrorService>(), Mock.Create<IDistributedTracePayloadHandler>(), _attribDefSvc, Mock.Create<IAdaptiveSampler>());
        }

        [TearDown]
        public void TearDown()
        {
            _transactionService.Dispose();
        }

        [Test]
        public void GetCurrentTransactionBuilder_ReturnsNull_IfNoCurrentTransactionBuilder()
        {
            // ACT
            var transaction = _transactionService.GetCurrentInternalTransaction();

            // ASSERT
            Assert.That(transaction, Is.Null);
        }

        [Test]
        public void GetCurrentTransactionBuilder_ReturnsCurrentTransactionBuilder_IfCurrentTransactionBuilderExists()
        {
            // ARRANGE
            var oldTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ACT
            var newTransaction = _transactionService.GetCurrentInternalTransaction();

            // ASSERT
            Assert.That(newTransaction, Is.Not.Null);
            Assert.That(newTransaction, Is.SameAs(oldTransaction));
        }

        [Test]
        public void GetOrCreateTransactionBuilder_ReturnsNewTransactionBuilder_IfNoCurrentTransactionBuilder()
        {
            // ACT
            var newTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ASSERT
            Assert.That(newTransaction, Is.Not.Null);

            var transactionName = newTransaction.ConvertToImmutableTransaction().TransactionName;
            Assert.That(transactionName.Name, Is.EqualTo(_initialTransactionName.Name));
        }

        [Test]
        public void GetOrCreateTransactionBuilder_ReturnsCurrentTransactionBuilder_IfCurrentTransactionBuilderExists()
        {
            // ARRANGE
            var oldTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ACT
            var newTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ASSERT
            Assert.That(newTransaction, Is.Not.Null);
            Assert.That(newTransaction, Is.SameAs(oldTransaction));
        }

        [Test]
        public void GetOrCreateTransactionBuilder_RunsProvidedAction_IfNoCurrentTransactionBuilder()
        {
            // ARRANGE
            var wasRun = false;

            // ACT
            _transactionService.GetOrCreateInternalTransaction(_initialTransactionName, () => wasRun = true);

            // ASSERT
            Assert.That(wasRun, Is.True);
        }

        [Test]
        public void GetOrCreateTransactionBuilder_DoesNotRunProvidedAction_IfCurrentTransactionBuilderExists()
        {
            // ARRANGE
            var wasRun = false;
            _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ACT
            _transactionService.GetOrCreateInternalTransaction(_initialTransactionName, () => wasRun = true);

            // ASSERT
            Assert.That(wasRun, Is.False);
        }

        [Test]
        public void GetOrCreateTransactionBuilder_IncrementsUnitOfWorkCount_IfCurrentTransactionBuilderExistsAndDoNotTrackAsUnitOfWorkIsFalse()
        {
            // ARRANGE
            var transaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            Assert.That(transaction.UnitOfWorkCount, Is.EqualTo(1));

            // ACT
            _transactionService.GetOrCreateInternalTransaction(_initialTransactionName, doNotTrackAsUnitOfWork: false);

            // ASSERT
            Assert.That(transaction.UnitOfWorkCount, Is.EqualTo(2));
        }

        [Test]
        public void GetOrCreateTransactionBuilder_DoesNotIncrementsUnitOfWorkCount_IfCurrentTransactionBuilderExistsAndDoNotTrackAsUnitOfWorkIsTrue()
        {
            // ARRANGE
            var transaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            Assert.That(transaction.UnitOfWorkCount, Is.EqualTo(1));

            // ACT
            _transactionService.GetOrCreateInternalTransaction(_initialTransactionName, doNotTrackAsUnitOfWork: true);

            // ASSERT
            Assert.That(transaction.UnitOfWorkCount, Is.EqualTo(1));
        }

        [Test]
        public void GetOrCreateTransactionBuilder_ReplacesExistingTransaction_IfCurrentTransactionBuilderExistsAndRecreateCountIsOver100()
        {
            // ARRANGE
            var oldTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);
            Enumerable.Range(0, 101).ForEach(_ => oldTransaction.NoticeNestedTransactionAttempt());

            Assert.That(oldTransaction.NestedTransactionAttempts, Is.EqualTo(101));

            // ACT
            var newTransaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);
            var newTransaction2 = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            Assert.Multiple(() =>
            {
                // ASSERT
                Assert.That(newTransaction, Is.Not.SameAs(oldTransaction));
                Assert.That(newTransaction2, Is.SameAs(newTransaction));
            });
        }

        [Test]
        public void when_multiple_transactionContexts_are_available_with_higher_provided_first_then_highest_priority_is_used()
        {
            // ARRANGE
            DictionaryTransactionContext(_highPriorityTransactionContext);
            ThrowingTransactionContext(_lowPriorityTransactionContext);

            // ACT
            var transaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ASSERT
            Assert.That(transaction, Is.Not.Null);
        }

        [Test]
        public void when_multiple_transactionContexts_are_available_with_lower_provided_first_then_highest_priority_is_used()
        {
            // ARRANGE
            DictionaryTransactionContext(_highPriorityTransactionContext);
            ThrowingTransactionContext(_lowPriorityTransactionContext);

            // ACT
            var transaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ASSERT
            Assert.That(transaction, Is.Not.Null);
        }

        [Test]
        public void when_TransactionContextFactory_throws_then_current_transaction_builder_is_null()
        {
            // ARRANGE
            ThrowingTransactionContext(_highPriorityTransactionContext);

            // ACT
            var transaction = _transactionService.GetOrCreateInternalTransaction(_initialTransactionName);

            // ASSERT
            Assert.That(transaction, Is.Null);
        }

        private static void ThrowingTransactionContext(IContextStorage<IInternalTransaction> transactionContext)
        {
            Mock.Arrange(() => transactionContext.CanProvide).Returns(true);
            Mock.Arrange(() => transactionContext.SetData((IInternalTransaction)Arg.AnyObject)).Throws<Exception>();
            Mock.Arrange(() => transactionContext.GetData()).Throws<Exception>();
        }

        private static void DictionaryTransactionContext(IContextStorage<IInternalTransaction> transactionContext)
        {
            const string key = "TEST";
            var dictionary = new Dictionary<string, object>();
            Mock.Arrange(() => transactionContext.CanProvide).Returns(true);
            Mock.Arrange(() => transactionContext.SetData((IInternalTransaction)Arg.AnyObject)).DoInstead((object value) =>
            {
                dictionary[key] = value;
            });
            Mock.Arrange(() => transactionContext.GetData()).Returns(() =>
            {
                if (!dictionary.ContainsKey(key))
                    return null;

                object value;
                dictionary.TryGetValue(key, out value);
                return value as IInternalTransaction;

            });
        }

        private static IContextStorageFactory CreateFactoryForTransactionContext(IContextStorage<IInternalTransaction> transactionContext)
        {
            var transactionContextFactory = Mock.Create<IContextStorageFactory>();
            Mock.Arrange(() => transactionContextFactory.CreateContext<IInternalTransaction>(Arg.AnyString)).Returns(transactionContext);
            return transactionContextFactory;
        }
    }
}
