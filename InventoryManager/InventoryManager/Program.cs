using InventoryManager.Model;
using InventoryManager.AppFunctions;
using InventoryManager.PrintInformation;
using InventoryManager.ValidInput;
using InventoryManager.MatchIndex;

//Create a list of products


//Prompt the User for a choice
string userChoice = OutputManager.PrintUserOptions();
DataValidation dataValidation = new DataValidation();
IndexSearch indexSearch = new IndexSearch();
ProductInformation productInformation = new ProductInformation();
ProductManager productManager = new ProductManager(dataValidation, indexSearch, productInformation);
ApplicationFunction applicationFunction = new ApplicationFunction(productManager);

//Perform the function of the application
do
{
    applicationFunction.AppFunctions(userChoice);
    userChoice = OutputManager.PrintUserOptions();
} while (userChoice.ToUpper() != "E");
//Looping Continuously till the User wishes to exit