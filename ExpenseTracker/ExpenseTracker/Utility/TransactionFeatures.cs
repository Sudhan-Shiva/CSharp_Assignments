using ExpenseTracker.Model;

namespace ExpenseTracker.Utility
{
    /// <summary>
    /// Handles the operations of the application
    /// </summary>
    public class TransactionFeatures
    {
        TransactionsManager transactionsManager;

        /// <summary>
        /// Represnts the features of the application
        /// </summary>
        /// <param name="mainTransactionsManager">The required methods to perform the functions of the application</param>
        public TransactionFeatures(TransactionsManager mainTransactionsManager)
        {
            transactionsManager = mainTransactionsManager;
        }

        /// <summary>
        /// To select the transaction feature that is to be executed
        /// </summary>
        /// <param name="userChoice">Integer based on which the transaction feature is selected</param>
        /// <returns></returns>
        public int ApplicationFunctions(int userChoice)
        {
            ApplicationOptions options = (ApplicationOptions) userChoice;
            switch (options)
            {
                case ApplicationOptions.ViewTransaction:
                    transactionsManager.ViewTransactions();
                    break;
                case ApplicationOptions.AddTransaction:
                    transactionsManager.AddTransaction();
                    break;
                case ApplicationOptions.DeleteTransaction:
                    transactionsManager.DeleteTransaction();
                    break;
                case ApplicationOptions.EditTransaction:
                    transactionsManager.ModifyTransaction();
                    break;
                case ApplicationOptions.SearchTransaction:
                    transactionsManager.SearchTransaction();
                    break;
                case ApplicationOptions.ViewTransactionSummary:
                    transactionsManager.GetSummaryOfTransaction();
                    break;
                case ApplicationOptions.Exit:
                    break;
                default:
                    break;
            }
            return userChoice;
        }
    }
}
