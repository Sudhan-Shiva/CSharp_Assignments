using ConsoleTables;
using ExpenseTracker.Model;

namespace ExpenseTracker.ConsoleUI
{
    /// <summary>
    /// Handles the output print operations
    /// </summary>
    public class OutputManager
    {
        /// <summary>
        /// To print the application start message.
        /// </summary>
        public void PrintStartMessage()
        {
            Console.WriteLine("---------WELCOME----------");
            Console.WriteLine("EXPENSE TRACKER");
        }

        /// <summary>
        /// To show the successful addition of a transaction. 
        /// </summary>
        public void PrintSuccessfulAddition()
        {
            Console.WriteLine("The Transaction Information has been successfully added.\n");
        }

        /// <summary>
        /// To show the successful deletion of a transaction. 
        /// </summary>
        public void PrintSuccessfulDeletion()
        {
            Console.WriteLine("The Transaction Information has been successfully deleted.\n");
        }

        /// <summary>
        /// To show the successful modification of a transaction. 
        /// </summary>
        public void PrintSuccessfulModification()
        {
            Console.WriteLine("The Transaction Information has been successfully edited.\n");
        }

        /// <summary>
        /// To show that the list is empty.
        /// </summary>
        public void PrintListIsEmpty()
        {
            Console.WriteLine("The transaction list is empty !!");
        }

        /// <summary>
        /// To show the complete transaction list in a table format.
        /// </summary>
        /// <param name="trackerList">The transaction list which is to be displayed</param>
        public void PrintTable(List<Transaction> trackerList)
        {
            ConsoleTable transactionTable = new ConsoleTable("Transaction Type", "Transaction Amount", "Transaction Date", "Source/Category");
            foreach (Transaction transaction in trackerList)
            {
                if (transaction is Income income)
                    transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, income.Source);
                else if (transaction is Expense expense)
                    transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, expense.Category);
            }
            transactionTable.Write();
        }

        /// <summary>
        /// To show the details of a specific transaction in a table format. 
        /// </summary>
        /// <param name="transaction">The transaction whose details is to be displayed</param>
        public void PrintSpecificTransactionInformation(Transaction transaction)
        {
            ConsoleTable transactionTable = new ConsoleTable("Transaction Type", "Transaction Amount", "Transaction Date", "Source/Category");
            if (transaction is Income income)
            {
                transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, income.Source);
            }
            else if (transaction is Expense expense)
            {
                transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, expense.Category);
            }
            transactionTable.Write();
        }

        /// <summary>
        /// To show the summary of the transactions
        /// </summary>
        /// <param name="totalIncome">The total amount of income in the transactions</param>
        /// <param name="totalExpense">The total amount of expense in the transactions</param>
        public void PrintTransactionSummary(int totalIncome, int totalExpense)
        {
            Console.WriteLine("Total Income : " + totalIncome);
            Console.WriteLine("Total Expense : " + totalExpense);
            Console.WriteLine("Net Balance : " + (totalIncome - totalExpense));
        }


        /// <summary>
        /// To show that there are no matches of the transaction
        /// </summary>
        public void PrintNoMatches()
        {
            Console.WriteLine("There are no matches found !!");
        }

        /// <summary>
        /// To show the application exit message
        /// </summary>
        public void PrintExitMessage()
        {
            Console.WriteLine("--------EXITING--------");
            Console.WriteLine("Press any key to exit");
        }
        public void PrintAlreadySameType()
        {
            Console.WriteLine("The provided transaction is already of the same type.");
        }
    }
}
