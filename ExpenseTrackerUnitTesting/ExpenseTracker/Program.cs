using ExpenseTracker.Utility;
using ExpenseTracker.InputValidation;
using ExpenseTracker.ConsoleUI;


DataValidation _dataValidation = new DataValidation();
InputManager _inputManager = new InputManager(_dataValidation);
OutputManager _outputManager = new OutputManager();
TransactionsManager _transactionsManager = new TransactionsManager(_inputManager, _outputManager);
TransactionFeatures _transactionFeatures = new TransactionFeatures(_transactionsManager, _inputManager);
int _userChoice;

_outputManager.PrintStartMessage();
do
{
    _userChoice = _transactionFeatures.ApplicationFunctions(_inputManager.GetUserChoice());
} while (_userChoice != 6);
_outputManager.PrintExitMessage();
Console.ReadKey();


