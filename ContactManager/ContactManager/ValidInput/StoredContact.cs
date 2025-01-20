using ContactManager.MatchIndex;
using ContactManager.Contact;

namespace ContactManager.ValidInput
{
    public class StoredContact
    {
        //Create the required object references
        IndexSearch indexSearch = new IndexSearch();
        //Method to check whether the given input is present in the contact list
        public int ContactPresent(List<ContactInformation> contactList, string inputField, bool isProductName)
        {
            bool isContactPresent = (indexSearch.ReturnIndex(contactList, inputField, isProductName) == -1);
            //Loop till the user gives a input present in the contact list
            while (isContactPresent)
            {
                Console.Write("No matches found !!\nGive a Valid input:");
                isContactPresent = (indexSearch.ReturnIndex(contactList, Console.ReadLine(), isProductName) == -1);
            }

            return (indexSearch.ReturnIndex(contactList, inputField, isProductName));
        }
    }
}
