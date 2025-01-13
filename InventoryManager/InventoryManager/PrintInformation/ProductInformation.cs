using InventoryManager.MatchIndex;
using InventoryManager.ProductClass;

namespace InventoryManager.PrintInformation
{
    public class ProductInformation
    {
        //Create the required object references 
        IndexSearch indexSearch = new IndexSearch();

        //Method to print all the information of the required product
        public void PrintProductInformation(List<Product> productList, string viewProduct, bool isProductName)
        {
            int printIndex = indexSearch.ReturnIndex(productList, viewProduct, isProductName);
            //If returned index is -1, it means that either the given input is invalid or it is not present in the list
            while (printIndex == -1)
            {
                PrintMessages.PrintInvalidInput();
                viewProduct = Console.ReadLine();
                printIndex = indexSearch.ReturnIndex(productList, viewProduct, isProductName);

            }
            //Print the information of the product
            Console.WriteLine($"Product Name : {productList[printIndex].ProductName}");
            Console.WriteLine($"Product ID : {productList[printIndex].ProductId}");
            Console.WriteLine($"Product Price : {productList[printIndex].ProductPrice}");
            Console.WriteLine($"Product Quantity : {productList[printIndex].ProductQuantity}");
        }
    }
}
