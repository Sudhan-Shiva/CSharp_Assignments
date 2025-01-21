using InventoryManager.Utility;
using InventoryManager.UserInterface;
using InventoryManager.ValidInput;

DataValidation dataValidation = new DataValidation();
InputManager inputManager = new InputManager();
ProductManager productManager = new ProductManager(dataValidation, inputManager);
ApplicationFunction applicationFunction = new ApplicationFunction(productManager);

string userChoice;

do
{
    userChoice = inputManager.GetUserOptions();
    applicationFunction.AppFunctions(userChoice);
} while (userChoice.ToUpper() != "E");
