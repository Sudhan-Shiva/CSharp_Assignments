using ContactManager.ValidInput;
using ContactManager.Model;
using ContactManager.DisplayInformation;

namespace ContactManager.MatchIndex
{
    public class IndexSearch
    {
        GetValidInput getValidInput = new GetValidInput();
        //Create the required object references 
        DataValidation dataValidation = new DataValidation();
        //Method to return the index of the matching contact in the list
        public int ReturnIndex(List<Model.Contact> contactList, string inputParameter, bool isContactName)
        {
            foreach (Model.Contact contact in contactList)
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
        public bool isNameOrPhoneNumberPresent(Model.Contact contact, string inputParameter, bool isContactName)
        {
            if (isContactName)
            {
                return contact.Name == inputParameter;
            }

            else
            {
                return contact.PhoneNumber == getValidInput.GetValidPhoneNumber(inputParameter);
            }
        }
    }
}
