using ExpenseTracker.ConsoleUI;
using ExpenseTracker.InputValidation;
using ExpenseTracker.Model;
using ExpenseTracker.Utility;
using Moq;
using NUnit.Framework;

namespace ExpenseTrackerTests
{
    internal class TransactionFeaturesTests
    {
        private Mock<TransactionsManager> _mockTransactionsManager;
        private TransactionFeatures _transactionFeatures;
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private DataValidation _dataValidation;

        [SetUp]
        public void Setup()
        {
            _dataValidation = new DataValidation();
            _inputManager = new InputManager(_dataValidation);
            _outputManager = new OutputManager();
            _mockTransactionsManager = new Mock<TransactionsManager>(_inputManager, _outputManager);
            _transactionFeatures = new TransactionFeatures(_mockTransactionsManager.Object, _inputManager);
        }

        [Test]
        public void ApplicationFunctions_CallsViewTransactions_ForApplicationOptionsAsViewTransaction()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.ViewTransaction);

            // Assert
            _mockTransactionsManager.Verify(x => x.ViewTransactions(), Times.Once);
        }

        [Test]
        public void ApplicationFunctions_CallsAddTransaction_ForApplicationOptionsAsAddTransaction()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.AddTransaction);

            // Assert
            _mockTransactionsManager.Verify(x => x.AddTransaction(), Times.Once);
        }

        [Test]
        public void ApplicationFunctions_CallsDeleteTransaction_ForApplicationOptionsAsDeleteTransaction()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.DeleteTransaction);

            // Assert
            _mockTransactionsManager.Verify(x => x.DeleteTransaction(), Times.Once);
        }

        [Test]
        public void ApplicationFunctions_CallsModifyTransaction_ForApplicationOptionsAsEditTransaction()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.EditTransaction);

            // Assert
            _mockTransactionsManager.Verify(x => x.ModifyTransaction(), Times.Once);
        }

        [Test]
        public void ApplicationFunctions_CallsSearchTransaction_ForApplicationOptionsAsSearchTransaction()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.SearchTransaction);

            // Assert
            _mockTransactionsManager.Verify(x => x.SearchTransaction(), Times.Once);
        }

        [Test]
        public void ApplicationFunctions_CallsGetSummaryOfTransaction_ForApplicationOptionsAsViewTransactionSummary()
        {
            // Act
            _transactionFeatures.ApplicationFunctions(ApplicationOptions.ViewTransactionSummary);
            // Assert
            _mockTransactionsManager.Verify(x => x.GetSummaryOfTransaction(), Times.Once);
        }
    }
}
