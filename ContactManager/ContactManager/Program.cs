using ContactManager.Contact;
using ContactManager.DisplayMenuInformation;
using ContactManager.Utility;

//Create a list of contacts
List<ContactInformation> contactList = new List<ContactInformation>();

string userChoice;
//Perform the function of the application
do
{
    PrintMessages.PrintUserOptions();
    userChoice = Console.ReadLine();
    ApplicationFunction applicationFunction = new ApplicationFunction();
    applicationFunction.appFunctions(contactList, userChoice);  
} while (userChoice.ToUpper() != "E");
//Looping Continuously till the User wishes to exit
