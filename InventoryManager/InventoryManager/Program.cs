using InventoryManager.Utility;
using InventoryManager.UserInterface;
using InventoryManager.ValidInput;

DataValidation dataValidation = new DataValidation();
InputManager inputManager = new InputManager(dataValidation);
OutputManager outputManager = new OutputManager(inputManager);
ProductManager productManager = new ProductManager(inputManager, outputManager);
ApplicationFunction applicationFunction = new ApplicationFunction(productManager);
string userChoice;
do
{
    userChoice = applicationFunction.AppFunctions(inputManager.GetUserOptions());
} while (userChoice.ToUpper() != "E");
