namespace ExpenseTracker.Model
{
    /// <summary>
    /// To define the user options in the application
    /// </summary>
    public enum ApplicationOptions
    {
        /// <summary>
        /// To view all the transactions
        /// </summary>
        ViewTransaction,

        /// <summary>
        /// To add a new transaction
        /// </summary>
        AddTransaction,

        /// <summary>
        /// To delete an older transaction
        /// </summary>
        DeleteTransaction,

        /// <summary>
        /// To edit a transaction
        /// </summary>
        EditTransaction,

        /// <summary>
        /// To search for a specific transaction
        /// </summary>
        SearchTransaction,

        /// <summary>
        /// To view the transaction summary 
        /// </summary>
        ViewTransactionSummary,

        /// <summary>
        /// To exit the application
        /// </summary>
        Exit
    }

    /// <summary>
    /// To define the edit choices in the transaction
    /// </summary>
    public enum UserEditChoice
    {
        /// <summary>
        /// Edit the transaction type
        /// </summary>
        EditTransactionType,

        /// <summary>
        /// Edit the transaction amount
        /// </summary>
        EditTransactionAmount,

        /// <summary>
        /// Edit the transaction date
        /// </summary>
        EditTransactionDate,

        /// <summary>
        /// Edit the transaction details
        /// </summary>
        EditTransactionDetails
    }
    
    /// <summary>
    /// To define the types of transaction
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Choose the transaction type as income
        /// </summary>
        INCOME,

        /// <summary>
        /// Choose the transaction type as expense
        /// </summary>
        EXPENSE
    }
}
