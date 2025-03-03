using ExpenseTracker.Model;
using ExpenseTracker.ConsoleUI;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("ExpenseTrackerTests")]

/// <summary>
/// Defines the transaction list and operations in the application.
/// </summary>
public class TransactionsManager
{
    /// <summary>
    /// Represents the transaction list
    /// </summary>
    private List<Transaction> _trackerList = new();
    private InputManager _inputManager;
    private OutputManager _outputManager;

    /// <summary>
    /// Constructor block
    /// </summary>
    /// <param name="mainInputManager">Provides the required input methods</param>
    /// <param name="mainOutputManager">Provides the required output methods</param>
    public TransactionsManager(InputManager mainInputManager, OutputManager mainOutputManager)
    {
        _inputManager = mainInputManager;
        _outputManager = mainOutputManager;
    }

    public List<Transaction> transactionRepository()
    {
        return _trackerList;
    }
    /// <summary>
    /// To check if the transaction list is empty.
    /// </summary>
    /// <returns>True if the list is empty, else false</returns>
    private bool isListEmpty()
    {
        return (_trackerList.Count == 0);
    }

    /// <summary>
    /// To view the transaction list.
    /// </summary>
    public virtual void ViewTransactions()
    {
        if (!isListEmpty())
            _outputManager.PrintTable(_trackerList);
        else
            _outputManager.PrintListIsEmpty();
    }

    /// <summary>
    /// To add a new transaction to the transaction list
    /// </summary>
    public virtual void AddTransaction()
    {
        TransactionType transactionChoice = _inputManager.GetTransactionType();
        switch (transactionChoice)
        {
            case TransactionType.Income:
                AddIncome();
                break;
            case TransactionType.Expense:
                AddExpense();
                break;
            default:
                _outputManager.PrintInvalidInput();
                AddTransaction();
                break;
        }
        _outputManager.PrintSuccessfulAddition();
    }

    private void AddExpense()
    {
        Expense expense = new("EXPENSE", _inputManager.GetTransactionAmount(), _inputManager.GetTransactionDate(), _inputManager.GetExpenseCategory());
        _trackerList.Add(expense);
        _outputManager.PrintSpecificTransactionInformation(expense);
    }

    private void AddIncome()
    {
        Income income = new("INCOME", _inputManager.GetTransactionAmount(), _inputManager.GetTransactionDate(), _inputManager.GetIncomeSource());
        _trackerList.Add(income);
        _outputManager.PrintSpecificTransactionInformation(income);
    }

    /// <summary>
    /// To delete a transaction from the list
    /// </summary>
    public virtual void DeleteTransaction()
    {
        if (!isListEmpty())
        {
            int deleteChoiceIndex = SelectTransactionIndex();
            if (deleteChoiceIndex > -1)
            {
                _trackerList.RemoveAt(deleteChoiceIndex);
                _outputManager.PrintSuccessfulDeletion();
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }
        else
        {
            _outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To modify the transaction details of a transaction
    /// </summary>
    public virtual void ModifyTransaction()
    {
        if (!isListEmpty())
        {
            int transactionIndex = SelectTransactionIndex();
            if (transactionIndex > -1)
            {
                EditTransactionDetails(transactionIndex);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }
        else
        {
            _outputManager.PrintListIsEmpty();
        }
    }

    private void EditTransactionDetails(int transactionIndex)
    {
        UserEditChoice fieldToEdit = _inputManager.GetModifyChoice();
        switch (fieldToEdit)
        {
            case UserEditChoice.EditTransactionType:
                EditTransactionType(transactionIndex);
                break;
            case UserEditChoice.EditTransactionAmount:
                _trackerList[transactionIndex].Amount = _inputManager.GetTransactionAmount();
                _outputManager.PrintSuccessfulModification();
                break;
            case UserEditChoice.EditTransactionDate:
                _trackerList[transactionIndex].DateOfTransaction = _inputManager.GetTransactionDate();
                _outputManager.PrintSuccessfulModification();
                break;
            case UserEditChoice.EditTransactionDetails:
                EditTransactionRemarks(transactionIndex);
                break;
            default:
                EditTransactionDetails(transactionIndex);
                break;
        }
    }

    private void EditTransactionRemarks(int transactionIndex)
    {
        if (_trackerList[transactionIndex] is Income incomeType)
        {
            incomeType.Source = _inputManager.GetIncomeSource();
        }
        else if (_trackerList[transactionIndex] is Expense expenseType)
        {
            expenseType.Category = _inputManager.GetExpenseCategory();
        }
        _outputManager.PrintSuccessfulModification();
    }

    private void EditTransactionType(int transactionIndex)
    {
        string transactionType = "";
        TransactionType editTransactionTypeChoice = _inputManager.GetTransactionType();
        if (editTransactionTypeChoice == TransactionType.Income)
            transactionType = TransactionType.Income.ToString().ToUpper();
        else if (editTransactionTypeChoice == TransactionType.Expense)
            transactionType = TransactionType.Expense.ToString().ToUpper();
        else
        {
            _outputManager.PrintInvalidInput();
            EditTransactionType(transactionIndex);
        }
        if (_trackerList[transactionIndex] is Income && transactionType == "EXPENSE")
        {
            EditToExpense(transactionIndex);
        }
        else if (_trackerList[transactionIndex] is Expense && transactionType == "INCOME")
        {
            EditToIncome(transactionIndex);
        }
        else if ((_trackerList[transactionIndex] is Expense && transactionType == "EXPENSE") || (_trackerList[transactionIndex] is Income && transactionType == "INCOME"))
        {
            _outputManager.PrintAlreadySameType();
        }
    }

    internal void EditToExpense(int transactionIndex)
    {
        Expense expenseTransaction = new Expense("EXPENSE", _trackerList[transactionIndex].Amount, _trackerList[transactionIndex].DateOfTransaction, _inputManager.GetExpenseCategory());
        _trackerList[transactionIndex] = expenseTransaction;
        _outputManager.PrintSuccessfulModification();
    }

    internal void EditToIncome(int transactionIndex)
    {
        Income incomeTransaction = new Income("INCOME", _trackerList[transactionIndex].Amount, _trackerList[transactionIndex].DateOfTransaction, _inputManager.GetIncomeSource());
        _trackerList[transactionIndex] = incomeTransaction;
        _outputManager.PrintSuccessfulModification();
    }

    /// <summary>
    /// To search for a particular transaction
    /// </summary>
    public virtual int SearchTransaction()
    {
        if (!isListEmpty())
        {
            string searchTransactionType = "";
            TransactionType editTransactionTypeChoice = _inputManager.GetTransactionType();
            if (editTransactionTypeChoice == TransactionType.Income)
                searchTransactionType = "INCOME";
            else if (editTransactionTypeChoice == TransactionType.Expense)
                searchTransactionType = "EXPENSE";
            else
            {
                _outputManager.PrintInvalidInput();
                editTransactionTypeChoice = _inputManager.GetTransactionType();
            }
            DateOnly deleteChoiceDate = _inputManager.GetTransactionDate();
            int numberOfMatchingChoices = 0;
            int matchedIndex = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == searchTransactionType)
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    _outputManager.PrintSpecificTransactionInformation(transaction);
                }
            }

            if (numberOfMatchingChoices == 0)
            {
                _outputManager.PrintNoMatches();
            }

            return numberOfMatchingChoices;
        }
        else
        {
            _outputManager.PrintListIsEmpty();
        }

        return 0;
    }

    /// <summary>
    /// To get the transaction summary
    /// </summary>
    public virtual void GetSummaryOfTransaction()
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
            _outputManager.PrintTransactionSummary(totalIncome, totalExpense);
        }
        else
        {
            _outputManager.PrintListIsEmpty();
        }
    }

    /// <summary>
    /// To select the index of the transaction that must be accessed
    /// </summary>
    /// <returns>The index of the transaction that must be accessed</returns>
    private int SelectTransactionIndex()
    {
        string userChoiceOfType = AssignTransactionType();
        if (!(_trackerList.FindIndex(x => x.Type == userChoiceOfType) == -1))
        {
            DateOnly userChoiceOfDate;
            int numberOfMatchingChoices;
            FindMatchingChoices(userChoiceOfType, out userChoiceOfDate, out numberOfMatchingChoices);
            return GetTransactionChoice(userChoiceOfType, userChoiceOfDate, numberOfMatchingChoices);
        }
        return -1;
    }

    private int GetTransactionChoice(string userChoiceOfType, DateOnly userChoiceOfDate, int numberOfMatchingChoices)
    {
        if (numberOfMatchingChoices > 0)
        {
            int matchedIndex = 0;
            int deleteChoiceIndex = _inputManager.GetTransactionIndex();
            if (deleteChoiceIndex <= numberOfMatchingChoices)
            {
                numberOfMatchingChoices = 0;
                foreach (Transaction transaction in _trackerList)
                {
                    if (transaction.DateOfTransaction == userChoiceOfDate && transaction.Type == userChoiceOfType)
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
        }
        return -1;
    }

    private int FindMatchingChoices(string userChoiceOfType, out DateOnly userChoiceOfDate, out int numberOfMatchingChoices)
    {
        userChoiceOfDate = _inputManager.GetTransactionDate();
        numberOfMatchingChoices = 0;
        bool transactionTypePresent = false;
        foreach (Transaction transaction in _trackerList)
        {
            if (transaction.Type == userChoiceOfType)
            {
                transactionTypePresent = true;
                if (transaction.DateOfTransaction == userChoiceOfDate)
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    _outputManager.PrintSpecificTransactionInformation(transaction);
                }
            }
        }

        return numberOfMatchingChoices;
    }

    private string AssignTransactionType()
    {
        string userChoiceOfType = "";
        TransactionType selctTransactionTypeChoice = _inputManager.GetTransactionType();
        if (selctTransactionTypeChoice == TransactionType.Income)
            userChoiceOfType = "INCOME";
        else if (selctTransactionTypeChoice == TransactionType.Expense)
            userChoiceOfType = "EXPENSE";
        else
        {
            _outputManager.PrintInvalidInput();
            SelectTransactionIndex();
        }

        return userChoiceOfType;
    }
}
