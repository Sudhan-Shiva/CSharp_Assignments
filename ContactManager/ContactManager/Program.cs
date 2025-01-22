using ContactManager.Model;
using ContactManager.DisplayInformation;
using ContactManager.Utility;

//Create a list of contacts
List<Contact> contactList = new List<Contact>();
ApplicationWorking applicationWorking = new ApplicationWorking();

string userChoice;
//Perform the function of the application
do
{
    PrintMessages.PrintUserOptions();
    userChoice = Console.ReadLine();
    switch (userChoice.ToUpper())
    {
        //Add New Contact Information
        case "A":
            applicationWorking.AddContact(contactList);
            break;
        //Search for Specific Contact Information
        case "S":
            applicationWorking.SearchContact(contactList);
            break;
        //Delete the Specific Contact Information
        case "D":
            applicationWorking.DeleteContact(contactList);
            break;
        //Modify the Contact Information
        case "M":
            applicationWorking.ModifyContact(contactList);
            break;
        //View all the Contact Names in the Contact List
        case "V":
            applicationWorking.ViewContact(contactList);
            break;
        default:
            PrintMessages.DisplayMessage("The Input is invalid !!", ConsoleColor.Red);
            break;
    }
} while (userChoice.ToUpper() != "E");
