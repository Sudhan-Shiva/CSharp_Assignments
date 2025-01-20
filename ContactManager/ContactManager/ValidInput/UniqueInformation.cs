﻿using ContactManager.Model;
using ContactManager.MatchIndex;

namespace ContactManager.ValidInput
{
    public class UniqueInformation
    {
        //Create the required object references
        IndexSearch indexSearch = new IndexSearch();

        //Method to Prompt the user for a distinct input for Contact Name and Contact Phone Number
        public string DistinctInputs(List<Model.Contact> contactList, string inputParameter, bool isContactName)
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
