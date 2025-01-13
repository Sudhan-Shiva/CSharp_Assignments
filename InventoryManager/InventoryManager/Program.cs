using InventoryManager.ProductClass;
using InventoryManager.AppFunctions;
using InventoryManager.PrintInformation;

//Create a list of products
List<Product> productList = new List<Product>();

//Prompt the User for a choice
string userChoice = PrintMessages.PrintUserOptions();

//Perform the function of the application
do
{
    ApplicationFunction applicationFunction = new ApplicationFunction();
    applicationFunction.appFunctions(productList, userChoice);
    userChoice = PrintMessages.PrintUserOptions();
} while (userChoice.ToUpper() != "E");
//Looping Continuously till the User wishes to exit