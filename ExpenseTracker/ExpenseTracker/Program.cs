using ExpenseTracker.Utility;
using ExpenseTracker.InputValidation;
using ExpenseTracker.ConsoleUI;

DataValidation dataValidation = new DataValidation();
InputManager inputManager = new InputManager(dataValidation);
OutputManager outputManager = new OutputManager();
TransactionsManager transactionsManager = new TransactionsManager(inputManager, outputManager);
TransactionFeatures transactionFeatures = new TransactionFeatures(transactionsManager, inputManager);
int userChoice;
outputManager.PrintStartMessage();
do
{
    userChoice = transactionFeatures.ApplicationFunctions(inputManager.GetUserChoice());
} while (userChoice != 6);
outputManager.PrintExitMessage();
Console.ReadKey();