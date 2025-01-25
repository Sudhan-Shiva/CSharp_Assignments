using ExpenseTracker.InputValidation;

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
        DataValidation dataValidation;

        /// <summary>
        /// Required class for input validation
        /// </summary>
        /// <param name="mainDataValidation"> To validate the input data </param>
        public InputManager(DataValidation mainDataValidation)
        {
            dataValidation = mainDataValidation;
        }

        /// <summary>
        /// To get the choice of the user for the function of the application
        /// </summary>
        /// <returns>Integer corresponding to the function that is to be performed</returns>
        public int GetUserChoice()
        {
            Console.WriteLine("\n[0] View all previous transaction\n[1] Add new transcation\n[2] Delete older transaction\n[3] Edit Older transaction\n[4] Search the Tracker List\n[5] View Transacton Summary\n[6] Exit ");
            Console.Write("Select the action to be performed :");
            int userChoice = GetValidInteger(Console.ReadLine());
            while (!(userChoice >= 0 && userChoice <= 6))
            {
                userChoice = GetValidInteger(ReplaceInvalidInput());
            }
            return userChoice;
        }

        /// <summary>
        /// To get the type of the input transaction
        /// </summary>
        /// <returns>Integer corresponding to the type of the transaction</returns>
        public int GetTransactionType()
        {
            Console.Write("[0] INCOME\n[1] EXPENSE\nEnter the Transaction Type :  ");
            int transactionType = GetValidInteger(Console.ReadLine());
            while (transactionType != 0 && transactionType != 1)
            {
                transactionType = GetValidInteger(ReplaceInvalidInput());
            }
            return transactionType;
        }

        /// <summary>
        /// To get the amount of the transaction
        /// </summary>
        /// <returns>The amount of the transaction</returns>
        public int GetTransactionAmount()
        {
            Console.Write("Enter the Transaction Amount :  ");
            int transactionAmount = GetValidInteger(Console.ReadLine());
            return transactionAmount;
        }

        /// <summary>
        /// To get the date of the transaction
        /// </summary>
        /// <returns>The date of the transaction</returns>
        public DateOnly GetTransactionDate()
        {
            Console.Write("Enter the Date of Transaction :  ");
            DateOnly transactionDate = GetValidDate(Console.ReadLine());
            return transactionDate;
        }

        /// <summary>
        /// To get the source of the income
        /// </summary>
        /// <returns>The source of the income</returns>
        public string GetIncomeSource()
        {
            Console.Write("Enter the Source of Income : ");
            string incomeSource = GetValidInput(Console.ReadLine());
            return incomeSource;
        }

        /// <summary>
        /// To get the category of the expense
        /// </summary>
        /// <returns>The category of the expense</returns>
        public string GetExpenseCategory()
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
        public string ReplaceEmptyInput()
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
        public string GetValidInput(string inputParameter)
        {
            while (dataValidation.IsDataEmpty(inputParameter))
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
        public int GetValidInteger(string inputParameter)
        {
            while (!dataValidation.IsInputInt(inputParameter))
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
        public DateOnly GetValidDate(string inputParameter)
        {
            while (!dataValidation.IsInputDate(inputParameter))
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
        public int GetModifyChoice()
        {
            Console.WriteLine("[0] Transaction Type\n[1] Transaction Amount\n[2] Transaction Date\n[3] Transaction Details");
            Console.Write("Select the field to edit :");
            int fieldToEdit = GetValidInteger(Console.ReadLine());
            while(!(fieldToEdit>=0 && fieldToEdit <=3))
            {
                fieldToEdit = GetValidInteger(ReplaceInvalidInput());
            }
            return fieldToEdit;
        }

        /// <summary>
        /// To get the index of the transaction that must be accessed in the printed transactions
        /// </summary>
        /// <returns>The index of the transaction that must be accessed in the printed transactions</returns>
        public int GetTransactionIndex()
        {
            Console.Write("Select the transaction index : ");
            int deleteChoiceIndex = GetValidInteger(Console.ReadLine());
            return deleteChoiceIndex;
        }
    }
}
