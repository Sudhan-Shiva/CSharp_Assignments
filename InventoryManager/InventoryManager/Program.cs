using InventoryManager.Model;
using InventoryManager.AppFunctions;
using InventoryManager.PrintInformation;

//Create a list of products


//Prompt the User for a choice
string userChoice = InputManager.PrintUserOptions();

ApplicationFunction applicationFunction = new ApplicationFunction();

//Perform the function of the application
do
{
    applicationFunction.appFunctions(userChoice);
    userChoice = InputManager.PrintUserOptions();
} while (userChoice.ToUpper() != "E");
//Looping Continuously till the User wishes to exit