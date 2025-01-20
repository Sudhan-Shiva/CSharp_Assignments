﻿using ContactManager.DisplayInformation;
using ContactManager.MatchIndex;
using ContactManager.ValidInput;

namespace ContactManager.Utility
{
    public class ApplicationWorking
    {
        //Create the required object references
        IndexSearch indexSearch = new IndexSearch();
        UniqueInformation uniqueInformation = new UniqueInformation();
        StoredContact storedContact = new StoredContact();
        GetValidInput getValidInput = new GetValidInput();

        //Method to add new contacts in the list
        public void AddContact(List<Model.Contact> contactList)
        {
            Console.Write("Enter the Contact Name :  ");
            string contactName = uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), true);
            Console.Write("Enter the Contact Email :  ");
            string contactEmail = getValidInput.GetValidEmail(Console.ReadLine());
            Console.Write("Enter the Contact Phone Number :  ");
            long contactPhoneNumber = getValidInput.GetValidPhoneNumber(uniqueInformation.DistinctInputs(contactList, Console.ReadLine(), false));
            Console.Write("Enter the Contact Remarks : ");
            string contactRemarks = Console.ReadLine();
            Model.Contact contact = new Model.Contact(contactName, contactEmail, contactPhoneNumber, contactRemarks);
            contactList.Add(contact);
            Console.WriteLine("The contact Information has been successfully added.\n");
        }

        //Method to delete contacts in the list
        public void DeleteContact(List<Model.Contact> contactList)
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

        //Method to modify contact information in the list
        public void ModifyContact(List<Model.Contact> contactList)
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

        //Method to view the contact names in the list
        public void ViewContact(List<Model.Contact> contactList)
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

        //Method to search for a particular contact in the list
        public void SearchContact(List<Model.Contact> contactList)
        {
            if (contactList.Count > 0)
            {
                bool isSearchPresent = false;
                Console.Write("Search for the contact Name : ");
                string contactNameHint = Console.ReadLine();
                foreach (Model.Contact searchContact in contactList)
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
