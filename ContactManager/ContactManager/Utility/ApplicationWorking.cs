using ContactManager.DisplayInformation;
using ContactManager.MatchIndex;
using ContactManager.InputValidation;
using ContactManager.Model;

namespace ContactManager.Utility
{
    /// <summary>
    /// Defines the functionalities of the application
    /// </summary>
    public class ApplicationWorking
    {
        IndexSearch indexSearch = new IndexSearch();
        UniqueInformation uniqueInformation = new UniqueInformation();
        StoredContact storedContact = new StoredContact();
        GetValidInput getValidInput = new GetValidInput();

        /// <summary>
        /// Adds new contact to the contact list
        /// </summary>
        /// <param name="contactList">Represents the stored contact list</param>
        public void AddContact(List<Contact> contactList)
        {
            Console.Write("Enter the Contact Name :  ");
            string contactName = uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), true);
            Console.Write("Enter the Contact Email :  ");
            string contactEmail = getValidInput.GetValidEmail(Console.ReadLine());
            Console.Write("Enter the Contact Phone Number :  ");
            long contactPhoneNumber = getValidInput.GetValidPhoneNumber(uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), false));
            Console.Write("Enter the Contact Remarks : ");
            string contactRemarks = Console.ReadLine();
            Contact contact = new Contact(contactName, contactEmail, contactPhoneNumber, contactRemarks);
            contactList.Add(contact);
            Console.WriteLine("The contact Information has been successfully added.\n");
        }

        /// <summary>
        /// Deletes any contact in the list.
        /// </summary>
        /// <param name="contactList">Represents the stored contact list</param>
        public void DeleteContact(List<Contact> contactList)
        {
            if (contactList.Count > 0)
            {
                Console.Write("Enter the Name of the contact that must be deleted :  ");
                string deleteChoice = Console.ReadLine();
                int deleteIndex = indexSearch.ReturnIndex(contactList, deleteChoice, true);
                while (deleteIndex == -1)
                {
                    PrintMessages.PrintInvalidInput();
                    deleteChoice = Console.ReadLine();
                    deleteIndex = indexSearch.ReturnIndex(contactList, deleteChoice, true);
                }

                Console.WriteLine($"The contact Information of {deleteChoice} has been deleted successfully.");
                contactList.RemoveAt(deleteIndex);
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// Modify contact information in the list.
        /// </summary>
        /// <param name="contactList">Represents the stored contact list</param>
        public void ModifyContact(List<Contact> contactList)
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("Enter the Name of the Contact that must be edited :  ");
                int editChoice = storedContact.ContactPresent(contactList, Console.ReadLine(), true);
                Console.WriteLine("Choose the Information that must be edited : \n [N]ame \n [E]mail \n [P]hone Number \n [R]emarks \n");
                Console.Write("Type your Choice: ");
                string editField = Console.ReadLine();
                switch (editField.ToUpper())
                {
                    case "N":
                        Console.Write("Enter the Edited Contact Name : ");
                        contactList[editChoice].Name = uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), true);
                        break;
                    case "E":
                        Console.Write("Enter the Edited Contact Email : ");
                        contactList[editChoice].Email = getValidInput.GetValidEmail(Console.ReadLine());
                        break;
                    case "P":
                        Console.Write("Enter the Edited Contact Phone Number : ");
                        contactList[editChoice].PhoneNumber = getValidInput.GetValidPhoneNumber(uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), false));
                        break;
                    case "R":
                        Console.Write("Enter the Edited Contact Remarks : ");
                        contactList[editChoice].Remarks = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("The Provided input is invalid !!");
                        break;
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// View the contact names in the list.
        /// </summary>
        /// <param name="contactList">Represents the stored contact list</param>
        public void ViewContact(List<Contact> contactList)
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("All the contact Names in the contact List are : ");
                for (int i = 1; i <= contactList.Count; i++)
                {
                    Console.WriteLine($"{i}.{contactList[i - 1].Name}");
                }
                Console.Write("Do you want to view the contact Information of any specific contact ?\nY/N : ");
                string viewChoice = Console.ReadLine();
                while (viewChoice.ToUpper() != "Y" && viewChoice.ToUpper() != "N")
                {
                    PrintMessages.PrintInvalidInput();
                    viewChoice = Console.ReadLine();
                }
                if (viewChoice.ToUpper() == "Y")
                {
                    Console.Write("Kindly provide the Name of the contact whose details must be viewed : ");
                    string searchValue = Console.ReadLine();
                    int searchIndex = indexSearch.ReturnIndex(contactList, searchValue, true);
                    if (searchIndex != -1)
                    {
                        PrintMessages.PrintContactInformation(contactList[searchIndex]);
                    }
                    else
                    {
                        PrintMessages.DisplayMessage("The input name is not present !!",ConsoleColor.Red);
                    }
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// Search for a particular contact in the list.
        /// </summary>
        /// <param name="contactList">Represents the stored contact list</param>
        public void SearchContact(List<Contact> contactList)
        {
            if (contactList.Count > 0)
            {
                bool isSearchPresent = false;
                Console.Write("Search for the contact Name : ");
                string contactNameHint = Console.ReadLine();
                foreach (Contact searchContact in contactList)
                {
                    if (searchContact.Name.Contains(contactNameHint))
                    {
                        int searchIndex = contactList.IndexOf(searchContact);
                        PrintMessages.PrintContactInformation(contactList[searchIndex]);
                        isSearchPresent = true;
                    }
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }
    }
}
