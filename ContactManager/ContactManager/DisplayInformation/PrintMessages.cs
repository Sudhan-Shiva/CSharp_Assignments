//Looping Continuously till the User wishes to exit
using ContactManager.Model;
namespace ContactManager.DisplayInformation
{
    public static class PrintMessages
    {
        //Method to print that the given input is invalid
        public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        public static void PrintContactInformation(Contact contact)
        {
            Console.WriteLine($"Contact Name : {contact.Name}");
            Console.WriteLine($"Contact Phone Number : {contact.PhoneNumber}");
            Console.WriteLine($"Contact Email : {contact.Email}");
            Console.WriteLine($"Contact Remarks : {contact.Remarks}\n");
        }

        public static void PrintInvalidInput()
        {
            DisplayMessage("The Provided input is invalid !!\nProvide the Input again : ", ConsoleColor.Red);
        }

        //Method to Print the user options and generate the user interface
        public static void PrintUserOptions()
        {
            DisplayMessage("\nHello!\nWhat do you want to do?\n[V]iew the Contact List\n[S]earch the Contact List\n[A]dd new Contact\n[M]odify the Contact List\n[D]elete the Contct\n[E]xit the Contact List\nType your Choice: ", ConsoleColor.Green);
        }

        //Method to print the contact list is empty
        public static void PrintListIsEmpty()
        {
            DisplayMessage("The contact list is empty !! ", ConsoleColor.Red);
        }
    }
}
