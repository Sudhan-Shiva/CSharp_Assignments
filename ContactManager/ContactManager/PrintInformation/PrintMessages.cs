//Looping Continuously till the User wishes to exit

namespace ContactManager.PrintInformation
{
    public static class PrintMessages
    {
        //Method to print that the given input is invalid
        public static void PrintInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
        }

        //Method to Print the user options and generate the user interface
        public static string PrintUserOptions()
        {
            Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Contact List\n[S]earch the Contact List\n[A]dd new Contact\n[M]odify the Contact List\n[D]elete the Contct\n[E]xit the Contact List\n");
            Console.Write("Type your Choice: ");
            return Console.ReadLine();
        }
        //Method to print the contact list is empty
        public static void PrintListIsEmpty()
        {
            Console.WriteLine("The Contact List is Empty");
        }

    }
}



