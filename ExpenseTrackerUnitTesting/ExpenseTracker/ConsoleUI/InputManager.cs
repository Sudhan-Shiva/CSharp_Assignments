using System.Runtime.CompilerServices;
using ExpenseTracker.InputValidation;
using ExpenseTracker.Model;

[assembly:InternalsVisibleTo("ExpenseTrackerTests")]

namespace ExpenseTracker.ConsoleUI
{
    /// <summary>
    /// Handles the data input operations
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// To validate the input data
        /// </summary>
        private DataValidation _dataValidation;

        /// <summary>
        /// Required class for input validation
        /// </summary>
        /// <param name="mainDataValidation"> To validate the input data </param>
        public InputManager(DataValidation mainDataValidation)
        {
            _dataValidation = mainDataValidation;
        }

        /// <summary>
        /// To get the choice of the user for the function of the application
        /// </summary>
        /// <returns>Integer corresponding to the function that is to be performed</returns>
        public ApplicationOptions GetUserChoice()
        {
            Console.Write($"\n[0] {ApplicationOptions.ViewTransaction}\n[1] {ApplicationOptions.AddTransaction}\n[2] {ApplicationOptions.DeleteTransaction}\n[3] {ApplicationOptions.EditTransaction}\n[4] {ApplicationOptions.SearchTransaction}\n[5] {ApplicationOptions.ViewTransactionSummary}\n[6] {ApplicationOptions.Exit}\nSelect the action to be performed :");
            int userChoice = GetValidInteger(Console.ReadLine());
            return (ApplicationOptions)userChoice;
        }

        /// <summary>
        /// To get the type of the input transaction
        /// </summary>
        /// <returns>Integer corresponding to the type of the transaction</returns>
        public virtual TransactionType GetTransactionType()
        {
            Console.Write($"[0] {TransactionType.Income}\n[1] {TransactionType.Expense}\nEnter the Transaction Type :  ");
            int transactionType = GetValidInteger(Console.ReadLine());
            while (transactionType != 0 && transactionType != 1)
            {
                transactionType = GetValidInteger(ReplaceInvalidInput());
            }
            return (TransactionType)transactionType;
        }

        /// <summary>
        /// To get the amount of the transaction
        /// </summary>
        /// <returns>The amount of the transaction</returns>
        public virtual int GetTransactionAmount()
        {
            Console.Write("Enter the Transaction Amount :  ");
            int transactionAmount = GetValidInteger(Console.ReadLine());
            return transactionAmount;
        }

        /// <summary>
        /// To get the date of the transaction
        /// </summary>
        /// <returns>The date of the transaction</returns>
        public virtual DateOnly GetTransactionDate()
        {
            Console.Write("Enter the Date of Transaction (DD/MM/YYYY) :  ");
            DateOnly transactionDate = GetValidDate(Console.ReadLine());
            return transactionDate;
        }

        /// <summary>
        /// To get the source of the income
        /// </summary>
        /// <returns>The source of the income</returns>
        public virtual string GetIncomeSource()
        {
            Console.Write("Enter the Source of Income : ");
            string incomeSource = GetValidInput(Console.ReadLine());
            return incomeSource;
        }

        /// <summary>
        /// To get the category of the expense
        /// </summary>
        /// <returns>The category of the expense</returns>
        public virtual string GetExpenseCategory()
        {
            Console.Write("Enter the Category of expense : ");
            string expenseCategory = GetValidInput(Console.ReadLine());
            return expenseCategory;
        }

        /// <summary>
        /// To get another input when the given input is invalid
        /// </summary>
        /// <returns>The input for replacing the invalid input</returns>
        public string ReplaceInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get another input when the given input is null or empty string
        /// </summary>
        /// <returns>The input for replacing the null or empty string input</returns>
        private string ReplaceEmptyInput()
        {
            Console.Write("The Provided input is empty !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get a valid input which is not null or empty string
        /// </summary>
        /// <param name="inputParameter">The input that is validated</param>
        /// <returns>A valid input which is not null or empty string</returns>
        internal string GetValidInput(string inputParameter)
        {
            while (_dataValidation.IsDataEmpty(inputParameter))
            {
                inputParameter = ReplaceEmptyInput();
            }
            return inputParameter;
        }

        /// <summary>
        /// To get a valid input which is of the required datatype integer.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is integer</returns>
        internal int GetValidInteger(string inputParameter)
        {
            while (!_dataValidation.IsInputInt(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }

        /// <summary>
        /// To get a valid input which is of the required datatype DateOnly.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is DateOnly</returns>
        internal DateOnly GetValidDate(string inputParameter)
        {
            while (!_dataValidation.IsInputDate(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            DateOnly.TryParse(inputParameter, out DateOnly validData);
            return validData;
        }

        /// <summary>
        /// To get the transaction detail that must be modified
        /// </summary>
        /// <returns>Integer corresponding to the detail that must be modified</returns>
        public virtual UserEditChoice GetModifyChoice()
        {
            Console.Write($"\n[0] {UserEditChoice.EditTransactionType}\n[1] {UserEditChoice.EditTransactionAmount}\n[2] {UserEditChoice.EditTransactionDate}\n[3] {UserEditChoice.EditTransactionDetails}\nSelect the field to edit :");
            int fieldToEdit = GetValidInteger(Console.ReadLine());
            return (UserEditChoice)fieldToEdit;
        }

        /// <summary>
        /// To get the index of the transaction that must be accessed in the printed transactions
        /// </summary>
        /// <returns>The index of the transaction that must be accessed in the printed transactions</returns>
        public virtual int GetTransactionIndex()
        {
            Console.Write("Select the transaction index : ");
            int userChoiceTransactionIndex = GetValidInteger(Console.ReadLine());
            return userChoiceTransactionIndex;
        }
    }
}
