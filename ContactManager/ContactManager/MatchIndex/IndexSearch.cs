using ContactManager.ValidInput;
using ContactManager.ContactClass;

namespace ContactManager.MatchIndex
{
    public class IndexSearch
    {
        //Create the required object references 
        DataValidation dataValidation = new DataValidation();
        //Method to return the index of the matching contact in the list
        public int ReturnIndex(List<ContactInformation> contactList, string inputParameter, bool isContactName)
        {
            foreach (ContactInformation contact in contactList)
            {
                if (isNameOrPhoneNumberPresent(contact, inputParameter, isContactName))
                {
                    //Return the Index of the matched contact
                    return contactList.IndexOf(contact);
                }
            }
            //If no matching contact is found, -1 is returned.
            return -1;
        }

        //Method to check for the matched contact based on name or phone number
        public bool isNameOrPhoneNumberPresent(ContactInformation contact, string inputParameter, bool isContactName)
        {
            return isContactName ? contact.Name == inputParameter : contact.PhoneNumber == dataValidation.CheckPhoneNumber(inputParameter);
        }
    }
}








