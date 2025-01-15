using ContactManager.ContactClass;
using ContactManager.MatchIndex;

namespace ContactManager.PrintInformation
{
    public class ContactDetails
    {
        //Create the required object references 
        IndexSearch indexSearch = new IndexSearch();

        //Method to print all the information of the required contact
        public void PrintContactInformation(List<ContactInformation> contactList, string viewContact, bool isContactName)
        {
            int printIndex = indexSearch.ReturnIndex(contactList, viewContact, isContactName);
            //If returned index is -1, it means that either the given input is invalid or it is not present in the list
            while (printIndex == -1)
            {
                PrintMessages.PrintInvalidInput();
                viewContact = Console.ReadLine();
                printIndex = indexSearch.ReturnIndex(contactList, viewContact, isContactName);

            }
            //Print the information of the contact
            Console.WriteLine($"Contact Name : {contactList[printIndex].Name}");
            Console.WriteLine($"Contact Phone Number : {contactList[printIndex].PhoneNumber}");
            Console.WriteLine($"Contact Email : {contactList[printIndex].Email}");
            Console.WriteLine($"Contact Remarks : {contactList[printIndex].Remarks}\n");
        }
    }
}




