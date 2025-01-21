using InventoryManager.MatchIndex;
using InventoryManager.PrintInformation;
using InventoryManager.ValidInput;

namespace InventoryManager.AppFunctions
{
    public class ApplicationFunction
    {
        ProductManager productManager;
        public ApplicationFunction(ProductManager mainProductManager)
        {
            productManager = mainProductManager;
        }
        //Method to switch between various functions of the application based on the userchoice
        public void AppFunctions(string userChoice)
        {
            switch (userChoice.ToUpper())
            {
                //Add New Product Information
                case "A":
                    productManager.AddProduct();
                    break;
                //Search for Specific Product Information
                case "S":
                    productManager.SearchProduct();
                    break;
                //Delete the Specific Product Information
                case "D":
                    productManager.DeleteProduct();
                    break;
                //Modify the Product Information
                case "M":
                    productManager.ModifyProduct();
                    break;
                //View all the Product Names in the Product List
                case "V":
                    productManager.ViewProduct();
                    break;
                //Sort the Products in the List according to Name or ID
                case "Q":
                    productManager.SortProduct();
                    break;
                default:
                    Console.WriteLine("The Provided input is invalid !!");
                    break;
            }
        }
    }
}