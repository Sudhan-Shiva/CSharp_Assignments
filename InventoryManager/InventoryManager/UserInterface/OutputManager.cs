using ConsoleTables;

namespace InventoryManager.UserInterface
{
    public static class OutputManager
    {
        //Method to print that the given input is invalid
        public static void ShowInvalidInput()
        {
            Console.Write("The Provided input is invalid !!");
        }

        //Method to Print the user options and generate the user interface
        public static string ShowUserOptions()
        {
            Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[Q]uickSort the Product List\n[D]elete the Product\n[E]xit the Product List\n");
            Console.Write("Type your Choice: ");
            return Console.ReadLine();
        }

        public static void ShowListIsEmpty()
        {
            Console.WriteLine("The Product List is Empty");
        }
        public static void ShowList(ConsoleTable productTable)
        {
            productTable.Write();
        }

        public static void ShowSuccessfulSorting()
        {
            Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
        }

        public static void ShowSuccessfulAddition()
        {
            Console.WriteLine("The Product Information has been successfully added.\n");
        }

        public static void ShowSuccessfulDeletion()
        {
            Console.WriteLine("The Product has been deleted successfully.");
        }

        public static void ShowSuccessfulModification()
        {
            Console.WriteLine("The Product has been deleted successfully.");
        }

        public static void ShowNameAndId(string productName, int productId)
        {
            Console.WriteLine($"Product Name : {productName} \n " +
                              $"Product ID : {productId}\n");
        }

        public static void ShowNoMatches()
        {
            Console.WriteLine("There are no matches found.");
        }

    }
}