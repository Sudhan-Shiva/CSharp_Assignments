namespace ExpenseTracker.Model
{
    /// <summary>
    /// Represents the details of the transaction
    /// </summary>
    public class Transaction

    {
        /// <summary>
        /// To access the type of the transaction
        /// </summary>
        public string Type;

        /// <summary>
        /// To access the amount of the transaction
        /// </summary>
        public int Amount;

        /// <summary>
        /// To access the date of the transaction
        /// </summary>
        public DateOnly DateOfTransaction;
    }

    /// <summary>
    /// Represents the derived class Expense
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Represents the category of the expense
        /// </summary>
        public string Category { get; set; }
    }

    /// <summary>
    /// Represents the derived class Income
    /// </summary>
    public class Income : Transaction
    {
        /// <summary>
        /// Represents the source of the income
        /// </summary>
        public string Source { get; set; }
    }
}
