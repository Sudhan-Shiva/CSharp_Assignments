using ContactManager.MatchIndex;
using ContactManager.Model;

namespace ContactManager.ValidInput
{
    /// <summary>
    /// Checks whether the given input is distinct and if not, prompts the user for a distinct one.
    /// </summary>
    public class UniqueInformation
    {
        IndexSearch indexSearch = new IndexSearch();

        /// <summary>
        /// Prompt the user for a distinct input for Contact Name and Contact Phone Number
        /// </summary>
        /// <param name="contactList">List containing the stored contacts.</param>
        /// <param name="inputParameter">Parameter(Name/Phone Number) to search for the required contact.</param>
        /// <param name="isContactName">Parameter whcih represents whether thw given input is a contact name.</param></param>
        /// <returns>Returns a unique contact name and phone number</returns>
        public string DistinctInputs(List<Contact> contactList, string inputParameter, bool isContactName)
        {
            //Loop till a unique input is received from the user
            while (indexSearch.ReturnIndex(contactList, inputParameter, isContactName) != -1)
            {
                Console.WriteLine("The Contact Field is Already Present !");
                Console.Write("Give a new Field : ");
                inputParameter = Console.ReadLine();
            }

            return inputParameter;
        }
    }
}
