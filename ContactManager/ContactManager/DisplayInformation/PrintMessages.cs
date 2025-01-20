using ContactManager.Model;

namespace ContactManager.DisplayInformation
{
    /// <summary>
    /// Prints the required messages
    /// </summary>
    public static class PrintMessages
    {
        /// <summary>
        /// Displays a message in the console with color.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="color">The color of the message text, defaults to white.</param>
        public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Displays the information about a specific contact.
        /// </summary>
        /// <param name="contact">The contact whose information is to be displayed</param>
        public static void PrintContactInformation(Contact contact)
        {
            Console.WriteLine($"Contact Name : {contact.Name}");
            Console.WriteLine($"Contact Phone Number : {contact.PhoneNumber}");
            Console.WriteLine($"Contact Email : {contact.Email}");
            Console.WriteLine($"Contact Remarks : {contact.Remarks}\n");
        }

        /// <summary>
        /// Prints that the input is invalid
        /// </summary>
        public static void PrintInvalidInput()
        {
            DisplayMessage("The Provided input is invalid !!\nProvide the Input again : ", ConsoleColor.Red);
        }

        /// <summary>
        /// Displays the user options and generates the user interface.
        /// </summary>
        public static void PrintUserOptions()
        {
            DisplayMessage("\nHello!\nWhat do you want to do?\n[V]iew the Contact List\n[S]earch the Contact List\n[A]dd new Contact\n[M]odify the Contact List\n[D]elete the Contct\n[E]xit the Contact List\nType your Choice: ", ConsoleColor.Green);
        }

        /// <summary>
        /// Prints that the contact list is empty.
        /// </summary>
        public static void PrintListIsEmpty()
        {
            DisplayMessage("The contact list is empty !! ", ConsoleColor.Red);
        }
    }
}
