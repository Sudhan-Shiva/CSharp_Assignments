using ContactManager.ContactClass;
using ContactManager.PrintInformation;
using ContactManager.AppFunctions;

//Create a list of contacts
List<ContactInformation> contactList = new List<ContactInformation>();

//Prompt the User for a choice
string userChoice = PrintMessages.PrintUserOptions();

//Perform the function of the application
while (userChoice.ToUpper() != "E")
{
    ApplicationFunction applicationFunction = new ApplicationFunction();
    applicationFunction.appFunctions(contactList, userChoice);
    userChoice = PrintMessages.PrintUserOptions();
}
//Looping Continuously till the User wishes to exit












