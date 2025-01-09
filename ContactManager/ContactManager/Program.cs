using System.Xml.Linq;

List<ContactInformation> contactList = new List<ContactInformation>();

//Prompt the User for a choice
Console.WriteLine("Hello!\nWhat do you want to do?\n[V]iew the Contact List\n[S]earch the Contact List\n[A]dd new Contact\n[M]odify the Contact List\n[D]elete the Contct\n[E]xit the Contact List\n");
Console.Write("Type your Choice: ");
string userChoice = Console.ReadLine();
//Looping Continuously till the User wishes to exit
do
{
    switch (userChoice)
    {
        //Add New Contact Information
        case "A":
        case "a":
            Console.Write("Enter the Contact Name :  ");
            string inputName = Console.ReadLine();
            string name = DistinctInputs(contactList, inputName, 0);
            Console.Write("Enter the Contact Email :  ");
            string inputEmail = Console.ReadLine();
            string email = DistinctInputs(contactList, inputEmail, 1);
            Console.Write("Enter the Contact Phone Number :  ");
            string inputPhoneNumber = Console.ReadLine();
            string distinctPhoneNumber = DistinctInputs(contactList, inputPhoneNumber, 2);
            long phoneNumber = CheckPhoneNumber(contactList, distinctPhoneNumber);
            Console.Write("If you have any remarks, kindly enter :  ");
            string remarks = Console.ReadLine();
            ContactInformation contactInformation = new ContactInformation(name, email, phoneNumber, remarks);
            contactList.Add(contactInformation);
            Console.WriteLine("The Contact Information has been successfully added.\n");
            break;
        //Search for Specific Contact Information
        case "S":
        case "s":
            if (contactList.Count > 0)
            {
                Console.Write("Search for the Contact Name : ");
                string contactHint = Console.ReadLine();
                bool isSearchPresent = false;
                for (int i = 1; i <= contactList.Count; i++)
                {
                    if (contactList[i - 1].Name.Contains(contactHint))
                    {
                        Console.WriteLine($"{i}.{contactList[i - 1].Name}");
                        isSearchPresent = true;
                    }
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
                else
                {
                    Console.Write("Do you want to view the Contact Information of the any specific Contact ?\nY/N : ");
                    string viewChoice = Console.ReadLine();
                    if (viewChoice == "Y" || viewChoice == "y")
                    {
                        Console.WriteLine("Kindly provide the Name of the Contact that must be viewed : ");
                        string toViewUser = Console.ReadLine();
                        Console.WriteLine($"Name : {contactList[ReturnIndex(contactList, toViewUser)].Name}");
                        Console.WriteLine($"Email : {contactList[ReturnIndex(contactList, toViewUser)].Email}");
                        Console.WriteLine($"Phone Number : {contactList[ReturnIndex(contactList, toViewUser)].PhoneNumber}");
                        Console.WriteLine($"Remarks : {contactList[ReturnIndex(contactList, toViewUser)].Remarks}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Contact Information has been added yet");
            }
            break;
        //Delete the Specific User Information
        case "d":
        case "D":
            Console.Write("Enter the Name of the Contact that must be deleted :  ");
            string deleteChoice = Console.ReadLine();
            Console.WriteLine($"The Contact Information of {deleteChoice} has been deleted successfully.");
            contactList.RemoveAt(ReturnIndex(contactList, deleteChoice));
            break;
        //Modify the Contact Information
        case "m":
        case "M":
            Console.WriteLine("Enter the Name of the Contact that must be edited :  ");
            string editChoice = Console.ReadLine();
            Console.WriteLine("Choose the Information that must be edited : \n [N]ame \n [E]mail \n [P]hone Number \n [R]emarks \n [A]ll");
            Console.Write("Type your Choice: ");
            string editField = Console.ReadLine();
            switch (editField)
            {
                case "N":
                case "n":
                    Console.WriteLine("Enter the Edited Name : ");
                    contactList[ReturnIndex(contactList, editChoice)].Name = Console.ReadLine();
                    break;
                case "E":
                case "e":
                    Console.WriteLine("Enter the Edited Email : ");
                    contactList[ReturnIndex(contactList, editChoice)].Email = Console.ReadLine();
                    break;
                case "P":
                case "p":
                    Console.WriteLine("Enter the Edited Phone Number : ");
                    contactList[ReturnIndex(contactList, editChoice)].PhoneNumber = CheckPhoneNumber(contactList, Console.ReadLine());
                    break;
                case "R":
                case "r":
                    Console.WriteLine("Enter the Edited Remarks : ");
                    contactList[ReturnIndex(contactList, editChoice)].Remarks = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Choice !!");
                    break;
            }
            break;
        //View all the Contact Names in the Contact List
        case "v":
        case "V":
            if (contactList.Count > 0)
            {
                Console.WriteLine("All the Contact Names in the Contact List are : ");
                for (int i = 1; i <= contactList.Count; i++)
                {
                    Console.WriteLine($"{i}.{contactList[i - 1].Name}");
                }
            }
            else
            {
                Console.WriteLine("The Contact List is Empty.");
            }
            break;
        default:
            Console.WriteLine("Invalid Choice !!");
            break;
    }
    Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Contact List\n[S]earch the Contact List\n[A]dd new Contact\n[M]odify the Contact List\n[D]elete the Contact\n[E]xit the Contact List\n");
    Console.Write("Type your Choice: ");
    userChoice = Console.ReadLine();
} while (userChoice != "e" && userChoice != "E"); // Exit the Application if the User gives the input as "E"

//Method to Return the index of the matched contact name in the list
int ReturnIndex(List<ContactInformation> contactList, string name)
{
    foreach (ContactInformation contact in contactList)
    {
        if (contact.Name == name)
        {
            return contactList.IndexOf(contact);
        }
    }
    return -1;
}
//Method to Prompt the user for Inputs till a unique input is received
string DistinctInputs(List<ContactInformation> contactList, string inputParameter, int indexParameter)
{
    if (!CheckRepeats(contactList, inputParameter, indexParameter))
    {
        return inputParameter;
    }
    else
    {
        while (true)
        {
            if (CheckRepeats(contactList, inputParameter, indexParameter))
            {
                Console.WriteLine("The Contact Field is Already Present !");
                Console.Write("Give a new Field : ");
                inputParameter = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The Contact Field has been successfully added.");
                return inputParameter;
            }
        }
    }
}

//Method to Check whether the given input field is already present in the contact list
bool CheckRepeats(List<ContactInformation> contactList,string inputParameter,int indexParameter)
{
    switch(indexParameter)
    {
        case 0:
            foreach(ContactInformation contact in contactList)
            {
                if (contact.Name == inputParameter)
                {
                    return true;
                }
                return false;
            }
            return false;
        case 1:
            foreach (ContactInformation contact in contactList)
            {
                if (contact.Email == inputParameter)
                {
                    return true;
                }
                return false;
            }
            return false;
        case 2:
            foreach (ContactInformation contact in contactList)
            {
                if (contact.PhoneNumber == CheckPhoneNumber(contactList,inputParameter))
                {
                    return true;                    
                }
                return false;             
            }
            return false;
        default:
            return false;         
    }
}

//Method to Check whether the given string for the Phone number can be formatted to the Phone number format
long CheckPhoneNumber(List<ContactInformation> contactList,string inputNumber)
{
    long phoneNumber;
    bool isPhoneNumberFormat = Int64.TryParse(inputNumber, out long parsedNumber);
    if (isPhoneNumberFormat)
    {
        return parsedNumber;
    }
    else
    {
        while (true)
        {
            if (!isPhoneNumberFormat)
            {
                Console.WriteLine("The Phone Number is invalid !!\nType the Phone numeber Again : ");
                isPhoneNumberFormat = Int64.TryParse(Console.ReadLine(), out parsedNumber);
            }
            else
            {
                return parsedNumber;
                Console.WriteLine("The Phone Number has  been successfully added");
                break;
            }
        }
    }
}

//Define Class to Store the Contact Information
public class ContactInformation
{
    public string Name;
    public string Email;
    public long PhoneNumber;
    public string Remarks;

    //Constructor Block
    public ContactInformation(string name, string email, long phoneNumber, string remarks)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Remarks = remarks;
    }
}





