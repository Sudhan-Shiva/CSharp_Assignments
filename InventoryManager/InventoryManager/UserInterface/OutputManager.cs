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
            Console.WriteLine($"Product Name : {productName} \n" +
                              $"Product ID : {productId}\n");
        }

        public static void ShowNoMatches()
        {
            Console.WriteLine("There are no matches found.");
        }

    }
}