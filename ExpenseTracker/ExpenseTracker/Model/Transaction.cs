namespace ExpenseTracker.Model
{
    /// <summary>
    /// Represents the details of the transaction
    /// </summary>
    public class Transaction

    {
        /// <summary>
        /// The type of the transaction
        /// </summary>
        private string _type;

        /// <summary>
        /// The amount of the transaction
        /// </summary>
        private int _amount;

        /// <summary>
        /// The date of the transaction
        /// </summary>
        private DateOnly _dateOnly;

        /// <summary>
        /// To access the type of the transaction
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// To access the amount of the transaction
        /// </summary>
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        /// <summary>
        /// To access the date of the transaction
        /// </summary>
        public DateOnly DateOfTransaction
        {
            get { return _dateOnly; }
            set { _dateOnly = value; }
        }
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
