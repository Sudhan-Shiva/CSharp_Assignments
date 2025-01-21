using InventoryManager.MatchIndex;
using InventoryManager.Model;
using ConsoleTables;

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
                InputManager.PrintInvalidInput();
                viewProduct = Console.ReadLine();
                printIndex = indexSearch.ReturnIndex(productList, viewProduct, isProductName);

            }

            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            //Print the information of the product

            productTable.AddRow(productList[printIndex].ProductName, productList[printIndex].ProductId, productList[printIndex].ProductPrice, productList[printIndex].ProductQuantity);
            productTable.Write();
        }

        public void PrintProductList(List<Product> productList)
        {
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            foreach (Product product in productList)
            {
                productTable.AddRow(product.ProductName, product.ProductId, product.ProductPrice, product.ProductQuantity);
            }           
            //Print the information of the product     
            productTable.Write();
        }
    }
}
