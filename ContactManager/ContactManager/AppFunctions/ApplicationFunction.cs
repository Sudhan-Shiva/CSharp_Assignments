using ContactManager.ContactClass;

namespace ContactManager.AppFunctions
{
    public class ApplicationFunction
    {
        //Create the required object references 
        ApplicationWorking applicationWorking = new ApplicationWorking();
        //Method to switch between various functions of the application based on the userchoice
        public void appFunctions(List<ContactInformation> contactList, string userChoice)
        {
            switch (userChoice.ToUpper())
            {
                //Add New Contact Information
                case "A":
                    applicationWorking.ContactAddition(contactList);
                    break;
                //Search for Specific Contact Information
                case "S":
                    applicationWorking.ContactSearch(contactList);
                    break;
                //Delete the Specific Contact Information
                case "D":
                    applicationWorking.ContactDeletion(contactList);
                    break;
                //Modify the Contact Information
                case "M":
                    applicationWorking.ContactModification(contactList);
                    break;
                //View all the Contact Names in the Contact List
                case "V":
                    applicationWorking.ContactView(contactList);
                    break;
                default:
                    Console.WriteLine("The Provided input is invalid !!");
                    break;
            }
        }
    }
}
