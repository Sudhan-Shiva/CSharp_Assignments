using ConsoleTables;

namespace InventoryManager.UserInterface
{
    /// <summary>
    /// Represents all the methods which shows the relevant messages in the console
    /// </summary>
    public static class OutputManager
    {
        /// <summary>
        /// To show that the given input is invalid
        /// </summary>
        public static void ShowInvalidInput()
        {
            Console.Write("The Provided input is invalid !!");
        }

        /// <summary>
        /// To show that the product list is empty
        /// </summary>
        public static void ShowListIsEmpty()
        {
            Console.WriteLine("The Product List is Empty");
        }

        /// <summary>
        /// To print the ConsoleTable given as the input
        /// </summary>
        /// <param name="productTable">The ConsoleTable that must be printed</param>
        public static void ShowList(ConsoleTable productTable)
        {
            productTable.Write();
        }

        /// <summary>
        /// To show that the list is sorted successfully
        /// </summary>
        public static void ShowSuccessfulSorting()
        {
            Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
        }

        /// <summary>
        /// To show that the product is added succesfully in the list
        /// </summary>
        public static void ShowSuccessfulAddition()
        {
            Console.WriteLine("The Product Information has been successfully added.\n");
        }

        /// <summary>
        /// To show that the product is deleted successfully from the list.
        /// </summary>
        public static void ShowSuccessfulDeletion()
        {
            Console.WriteLine("The Product has been deleted successfully.");
        }

        /// <summary>
        /// To show that the required product information is edited successfully.
        /// </summary>
        public static void ShowSuccessfulModification()
        {
            Console.WriteLine("The Product has been edited successfully.");
        }

        /// <summary>
        /// To display the product name and Id
        /// </summary>
        /// <param name="productName">The product name</param>
        /// <param name="productId">The product Id</param>
        public static void ShowNameAndId(string productName, int productId)
        {
            Console.WriteLine($"Product Name : {productName} \n" +
                              $"Product ID : {productId}\n");
        }

        /// <summary>
        /// To show that there are no matching products
        /// </summary>
        public static void ShowNoMatches()
        {
            Console.WriteLine("There are no matches found.");
        }

    }
}
