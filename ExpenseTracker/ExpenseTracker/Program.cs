using ExpenseTracker.Utility;
using ExpenseTracker.InputValidation;
using ExpenseTracker.ConsoleUI;
using ExpenseTracker.Model;

public class Program
{
    private static DataValidation _dataValidation = new DataValidation();
    private static InputManager _inputManager = new InputManager(_dataValidation);
    private static OutputManager _outputManager = new OutputManager();
    private static TransactionsManager _transactionsManager = new TransactionsManager(_inputManager, _outputManager);
    private static TransactionFeatures _transactionFeatures = new TransactionFeatures(_transactionsManager, _inputManager);
    private static ApplicationOptions _userChoice;
    static void Main()
    {
        _outputManager.PrintStartMessage();
        do
        {
            _userChoice = _transactionFeatures.ApplicationFunctions(_inputManager.GetUserChoice());
        } while (_userChoice != ApplicationOptions.Exit);
        _outputManager.PrintExitMessage();
        Console.ReadKey();
    }
}

