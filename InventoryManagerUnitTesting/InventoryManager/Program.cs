using InventoryManager.Utility;
using InventoryManager.UserInterface;
using InventoryManager.InputValidation;
using InventoryManager.Model;

DataValidation dataValidation = new DataValidation();
InputManager inputManager = new InputManager(dataValidation);
OutputManager outputManager = new OutputManager();

ProductManager productManager = new ProductManager(inputManager, outputManager);
ApplicationFunction applicationFunction = new ApplicationFunction(productManager);

int userChoice;
do
{
    userChoice = applicationFunction.AppFunctions(inputManager.GetUserOptions());
} while (userChoice != 6);
