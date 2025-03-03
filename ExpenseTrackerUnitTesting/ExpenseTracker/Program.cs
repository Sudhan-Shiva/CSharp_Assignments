using ExpenseTracker.Utility;
using ExpenseTracker.InputValidation;
using ExpenseTracker.ConsoleUI;
using ExpenseTracker.Model;

public class Program
{
    static void Main()
    {
        DataValidation _dataValidation = new DataValidation();
        InputManager _inputManager = new InputManager(_dataValidation);
        OutputManager _outputManager = new OutputManager();
        TransactionsManager _transactionsManager = new TransactionsManager(_inputManager, _outputManager);
        TransactionFeatures _transactionFeatures = new TransactionFeatures(_transactionsManager, _inputManager);
        ApplicationOptions _userChoice;
        _outputManager.PrintStartMessage();

        do
        {
            _userChoice = _transactionFeatures.ApplicationFunctions(_inputManager.GetUserChoice());
        } while (_userChoice != ApplicationOptions.Exit);
        _outputManager.PrintExitMessage();
        Console.ReadKey();
    }
}
