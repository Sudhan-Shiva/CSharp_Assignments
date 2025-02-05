using ExpenseTracker.ConsoleUI;
using ExpenseTracker.Model;

namespace ExpenseTracker.Utility
{
    /// <summary>
    /// Handles the operations of the application
    /// </summary>
    public class TransactionFeatures
    {
        private TransactionsManager _transactionsManager;
        private InputManager _inputManager;
        /// <summary>
        /// Represnts the features of the application
        /// </summary>
        /// <param name="mainTransactionsManager">The required methods to perform the functions of the application</param>
        public TransactionFeatures(TransactionsManager mainTransactionsManager, InputManager mainInputManager)
        {
            _transactionsManager = mainTransactionsManager;
            _inputManager = mainInputManager;
        }

        /// <summary>
        /// To select the transaction feature that is to be executed
        /// </summary>
        /// <param name="userChoice">Integer based on which the transaction feature is selected</param>
        /// <returns></returns>
        public ApplicationOptions ApplicationFunctions(ApplicationOptions userChoice)
        {
            switch (userChoice)
            {
                case ApplicationOptions.ViewTransaction:
                    _transactionsManager.ViewTransactions();
                    break;
                case ApplicationOptions.AddTransaction:
                    _transactionsManager.AddTransaction();
                    break;
                case ApplicationOptions.DeleteTransaction:
                    _transactionsManager.DeleteTransaction();
                    break;
                case ApplicationOptions.EditTransaction:
                    _transactionsManager.ModifyTransaction();
                    break;
                case ApplicationOptions.SearchTransaction:
                    _transactionsManager.SearchTransaction();
                    break;
                case ApplicationOptions.ViewTransactionSummary:
                    _transactionsManager.GetSummaryOfTransaction();
                    break;
                case ApplicationOptions.Exit:
                    break;
                default:
                    userChoice = _inputManager.GetUserChoice();
                    ApplicationFunctions(userChoice);
                    break;
            }
            return (ApplicationOptions) userChoice;
        }
    }
}
