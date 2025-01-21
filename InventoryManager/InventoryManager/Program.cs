using InventoryManager.Utility;
using InventoryManager.UserInterface;
using InventoryManager.ValidInput;

DataValidation dataValidation = new DataValidation();
InputManager productInformation = new InputManager();
ProductManager productManager = new ProductManager(dataValidation, productInformation);
ApplicationFunction applicationFunction = new ApplicationFunction(productManager);

string userChoice;

do
{
    userChoice = OutputManager.ShowUserOptions();
    applicationFunction.AppFunctions(userChoice);
} while (userChoice.ToUpper() != "E");