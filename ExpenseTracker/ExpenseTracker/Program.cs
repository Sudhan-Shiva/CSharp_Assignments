using ExpenseTracker.Utility;
using ExpenseTracker.InputValidation;
using ExpenseTracker.ConsoleUI;

public class Program
{
    private static DataValidation _dataValidation = new DataValidation();
    private static InputManager _inputManager = new InputManager(_dataValidation);
    private static OutputManager _outputManager = new OutputManager();
    private static TransactionsManager _transactionsManager = new TransactionsManager(_inputManager, _outputManager);
    private static TransactionFeatures _transactionFeatures = new TransactionFeatures(_transactionsManager, _inputManager);
    private static int _userChoice;
    static void Main()
    {
        _outputManager.PrintStartMessage();
        do
        {
            _userChoice = _transactionFeatures.ApplicationFunctions(_inputManager.GetUserChoice());
        } while (_userChoice != 6);
        _outputManager.PrintExitMessage();
        Console.ReadKey();
    }
}

