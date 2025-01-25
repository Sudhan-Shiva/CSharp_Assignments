using ExpenseTracker.Model;
using ExpenseTracker.ConsoleUI;

/// <summary>
/// Defines the transaction list and operations in the application.
/// </summary>
public class TransactionsManager
{
    /// <summary>
    /// Represents the transaction list
    /// </summary>
    private List<Transaction> _trackerList = new ();
    InputManager inputManager;
    OutputManager outputManager;

    /// <summary>
    /// Constructor block
    /// </summary>
    /// <param name="mainInputManager">Provides the required input methods</param>
    /// <param name="mainOutputManager">Provides the required output methods</param>
    public TransactionsManager(InputManager mainInputManager, OutputManager mainOutputManager)
    {
        inputManager = mainInputManager;
        outputManager = mainOutputManager;
    }

    /// <summary>
    /// To check if the transaction list is empty.
    /// </summary>
    /// <returns>True if the list is empty, else false</returns>
    public bool isListEmpty()
    {
        return (_trackerList.Count == 0);
    }

    /// <summary>
    /// To view the transaction list.
    /// </summary>
    public void ViewTransactions()
    {
        if (!isListEmpty())
            outputManager.PrintTable(_trackerList);
        else
            outputManager.PrintListIsEmpty();
    }

    /// <summary>
    /// To add a new transaction to the transaction list
    /// </summary>
    public void AddTransaction()
    {
        int transactionChoice = inputManager.GetTransactionType() ;
        TransactionType transactionType = (TransactionType) transactionChoice;
        switch(transactionType)
        {
            case TransactionType.Income:
                Income income = new ();
                income.Type = "INCOME";
                income.Amount = inputManager.GetTransactionAmount();
                income.DateOfTransaction = inputManager.GetTransactionDate();
                income.Source = inputManager.GetIncomeSource();
                _trackerList.Add(income);
                outputManager.PrintSpecificTransactionInformation(income);
                break;
            case TransactionType.Expense:
                Expense expense = new ();
                expense.Type = "EXPENSE";
                expense.Amount = inputManager.GetTransactionAmount();
                expense.DateOfTransaction = inputManager.GetTransactionDate();
                expense.Category = inputManager.GetExpenseCategory();
                _trackerList.Add(expense);
                outputManager.PrintSpecificTransactionInformation(expense);
                break;
            default:
                inputManager.ReplaceInvalidInput();
                break;
        }
        outputManager.PrintSuccessfulAddition();
    }

    /// <summary>
    /// To delete a transaction from the list
    /// </summary>
    public void DeleteTransaction()
    {
        if (!isListEmpty())
        {
            int deleteChoiceIndex = SelectTransactionIndex();
            if(deleteChoiceIndex > -1)
            {
                _trackerList.RemoveAt(deleteChoiceIndex);
                outputManager.PrintSuccessfulDeletion();
            }
            else
            {
                outputManager.PrintNoMatches();
            }            
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To modify the transaction details of a transaction
    /// </summary>
    public void ModifyTransaction()
    {
        if (!isListEmpty())
        {
            int transactionIndex = SelectTransactionIndex();
            if (transactionIndex > -1)
            {
                int fieldToEdit = inputManager.GetModifyChoice();
                UserEditChoice userEditChoice = (UserEditChoice)fieldToEdit;
                switch (userEditChoice)
                {
                    case UserEditChoice.EditTransactionType:
                        string transactionType = (inputManager.GetTransactionType() == 0) ? "INCOME" : "EXPENSE";
                        if (_trackerList[transactionIndex] is Income && transactionType == "EXPENSE")
                        {
                            Expense expenseTransaction = new Expense();
                            expenseTransaction.Type = transactionType;
                            expenseTransaction.Amount = _trackerList[transactionIndex].Amount;
                            expenseTransaction.DateOfTransaction = _trackerList[transactionIndex].DateOfTransaction;
                            expenseTransaction.Category = inputManager.GetExpenseCategory();
                            _trackerList.RemoveAt(transactionIndex);
                            _trackerList.Insert(transactionIndex, expenseTransaction);
                            outputManager.PrintSuccessfulModification();
                        }
                        else if (_trackerList[transactionIndex] is Expense && transactionType == "INCOME")
                        {
                            Income incomeTransaction = new Income();
                            incomeTransaction.Type = transactionType;
                            incomeTransaction.Amount = _trackerList[transactionIndex].Amount;
                            incomeTransaction.DateOfTransaction = _trackerList[transactionIndex].DateOfTransaction;
                            incomeTransaction.Source = inputManager.GetIncomeSource();
                            _trackerList.RemoveAt(transactionIndex);
                            _trackerList.Insert(transactionIndex, incomeTransaction);
                            outputManager.PrintSuccessfulModification();
                        }
                        else if((_trackerList[transactionIndex] is Expense && transactionType == "EXPENSE") || (_trackerList[transactionIndex] is Income && transactionType == "INCOME"))
                        {
                            Console.WriteLine("The provided transaction is already of the same type.");
                        }
                        break;
                    case UserEditChoice.EditTransactionAmount:
                        _trackerList[transactionIndex].Amount = inputManager.GetTransactionAmount();
                        outputManager.PrintSuccessfulModification();
                        break;
                    case UserEditChoice.EditTransactionDate:
                        _trackerList[transactionIndex].DateOfTransaction = inputManager.GetTransactionDate();
                        outputManager.PrintSuccessfulModification();
                        break;
                    case UserEditChoice.EditTransactionDetails:
                        if (_trackerList[transactionIndex] is Income incomeType)
                        {
                            incomeType.Source = inputManager.GetIncomeSource();
                        }
                        else if (_trackerList[transactionIndex] is Expense expenseType)
                        {
                            expenseType.Category = inputManager.GetExpenseCategory();
                        }
                        outputManager.PrintSuccessfulModification();
                        break;
                }
            }
            else
            {
                outputManager.PrintNoMatches();
            }
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To search for a particular transaction
    /// </summary>
    public void SearchTransaction()
    {
        if (!isListEmpty())
        {
            string deleteChoiceType = (inputManager.GetTransactionType() == 0) ? "INCOME" : "EXPENSE";
            DateOnly deleteChoiceDate = inputManager.GetTransactionDate();
            int numberOfMatchingChoices = 0;
            int matchedIndex = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    outputManager.PrintSpecificTransactionInformation(transaction);
                }
            }
            if (numberOfMatchingChoices == 0)
            {
                outputManager.PrintNoMatches();
            }
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To get the transaction summary
    /// </summary>
    public void GetSummaryOfTransaction()
    {
        if (!isListEmpty())
        {
            int totalIncome = 0;
            int totalExpense = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction is Income)
                {
                    totalIncome += transaction.Amount;
                }
                else if (transaction is Expense)
                {
                    totalExpense += transaction.Amount;
                }
            }
            outputManager.PrintTransactionSummary(totalIncome, totalExpense);
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To select the index of the transaction that must be accessed
    /// </summary>
    /// <returns>The index of the transaction that must be accessed</returns>
    public int SelectTransactionIndex()
    {
        string deleteChoiceType = (inputManager.GetTransactionType()==0) ? "INCOME" : "EXPENSE";
        DateOnly deleteChoiceDate = inputManager.GetTransactionDate();
        int numberOfMatchingChoices = 0;
        int matchedIndex = 0;
        foreach (Transaction transaction in _trackerList)
        {
            if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                outputManager.PrintSpecificTransactionInformation(transaction);
            }
        }

        if (numberOfMatchingChoices > 0)
        {
            int deleteChoiceIndex = inputManager.GetTransactionIndex();
            numberOfMatchingChoices = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
                {
                    numberOfMatchingChoices++;
                    if (deleteChoiceIndex == numberOfMatchingChoices)
                    {
                        matchedIndex = _trackerList.IndexOf(transaction);
                    }
                }
            }
            return matchedIndex;
        }
        return -1;
    }
}