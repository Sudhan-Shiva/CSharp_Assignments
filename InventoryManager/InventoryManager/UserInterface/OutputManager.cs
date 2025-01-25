using ConsoleTables;
using InventoryManager.Model;

namespace InventoryManager.UserInterface
{
    /// <summary>
    /// Represents all the methods which Prints the relevant messages in the console
    /// </summary>
    public class OutputManager
    {
        /// <summary>
        /// To Print that the given input is invalid
        /// </summary>
        public static void PrintInvalidInput()
        {
            Console.Write("The Provided input is invalid !!");
        }

        /// <summary>
        /// To Print that the product list is empty
        /// </summary>
        public static void PrintListIsEmpty()
        {
            Console.WriteLine("The Product List is Empty");
        }

        /// <summary>
        /// To print the ConsoleTable given as the input
        /// </summary>
        /// <param name="productTable">The ConsoleTable that must be printed</param>
        public static void PrintList(ConsoleTable productTable)
        {
            
        }

        /// <summary>
        /// To Print that the list is sorted successfully
        /// </summary>
        public static void PrintSuccessfulSorting()
        {
            Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
        }

        /// <summary>
        /// To Print that the product is added succesfully in the list
        /// </summary>
        public static void PrintSuccessfulAddition()
        {
            Console.WriteLine("The Product Information has been successfully added.\n");
        }

        /// <summary>
        /// To Print that the product is deleted successfully from the list.
        /// </summary>
        public static void PrintSuccessfulDeletion()
        {
            Console.WriteLine("The Product has been deleted successfully.");
        }

        /// <summary>
        /// To Print that the required product information is edited successfully.
        /// </summary>
        public static void PrintSuccessfulModification()
        {
            Console.WriteLine("The Product has been edited successfully.");
        }

        /// <summary>
        /// To Print that there are no matching products
        /// </summary>
        public static void PrintNoMatches()
        {
            Console.WriteLine("There are no matches found.");
        }
        /// <summary>
        /// Stores the information of a specific product as a ConsoleTable
        /// </summary>
        /// <param name="viewProduct">The product name/ID whose information must be stored</param>
        /// <param name="isProductName">Represents whether the input parameter to locate the product is name</param>
        /// <returns>The informaton of a specific product as a ConsoleTable</returns>
        public void SpecificProductInformation(List<Product> productList, int printIndex)
        {
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            productTable.AddRow(productList[printIndex].ProductName,
                                productList[printIndex].ProductId,
                                productList[printIndex].ProductPrice,
                                productList[printIndex].ProductQuantity);
            productTable.Write();
        }

        /// <summary>
        /// Stores the complete product list as a ConsoleTable
        /// </summary>
        /// <returns>The ConsoleTable containing the product List</returns>
        public void ProductList(List<Product> productList)
        {
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            foreach (Product product in productList)
            {
                productTable.AddRow(product.ProductName, product.ProductId, product.ProductPrice, product.ProductQuantity);
            }
            productTable.Write();
        }
    }
}
