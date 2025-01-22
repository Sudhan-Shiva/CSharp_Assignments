using ContactManager.MatchIndex;
using ContactManager.Model;

namespace ContactManager.ValidInput
{
    /// <summary>
    /// Prompts the user for a stored contact field to seacrh for the contact
    /// </summary>
    public class StoredContact
    {
        IndexSearch indexSearch = new IndexSearch();

        /// <summary>
        /// Loops until the given input is present in the contact list
        /// </summary>
        /// <param name="contactList">List containing the stored contacts.</param>
        /// <param name="inputField">Parameter(Name/Phone Number) to search for the required contact.</param>
        /// <param name="isContactName">Parameter whcih represents whether thw given input is a contact name.</param></param>
        /// <returns>returns the index of the matched contact</returns>
        public int ContactPresent(List<Contact> contactList, string inputField, bool isContactName)
        {
            bool isContactPresent = (indexSearch.ReturnIndex(contactList, inputField, isContactName) == -1);
            while (isContactPresent)
            {
                Console.Write("No matches found !!\nGive a Valid input:");
                isContactPresent = (indexSearch.ReturnIndex(contactList, Console.ReadLine(), isContactName) == -1);
            }

            return (indexSearch.ReturnIndex(contactList, inputField, isContactName));
        }
    }
}
