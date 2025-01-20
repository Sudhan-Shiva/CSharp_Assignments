using ContactManager.ValidInput;

namespace ContactManager.MatchIndex
{
    /// <summary>
    /// Searches and returs the index of a matching contact
    /// </summary>
    public class IndexSearch
    {
        GetValidInput getValidInput = new GetValidInput();

        /// <summary>
        /// Returns the index of the matching contact in the list
        /// </summary>
        /// <param name="contactList">List containing the stored contacts.</param>
        /// <param name="inputParameter">Parameter(Name/Phone Number) to search for the required contact.</param>
        /// <param name="isContactName">Parameter whcih represents whether thw given input is a contact name.</param>
        /// <returns></returns>
        public int ReturnIndex(List<Model.Contact> contactList, string inputParameter, bool isContactName)
        {
            foreach (Model.Contact contact in contactList)
            {
                if (isNameOrPhoneNumberPresent(contact, inputParameter, isContactName))
                {
                    return contactList.IndexOf(contact);
                }
            }

            return -1;
        }

        /// <summary>
        ///  Checks for the matched contact based on name or phone number
        /// </summary>
        /// <param name="contact">Contact whose information is compared.</param>
        /// <param name="inputParameter">Parameter(Name/Phone Number) to search for the required contact</param>
        /// <param name="isContactName">Parameter whcih represents whether thw given input is a contact name.</param>
        /// <returns></returns>
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
