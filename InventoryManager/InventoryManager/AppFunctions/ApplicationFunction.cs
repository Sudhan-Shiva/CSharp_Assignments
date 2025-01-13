using InventoryManager.ProductClass;

namespace InventoryManager.AppFunctions
{
    public class ApplicationFunction
    {
        //Create the required object references 
        ApplicationWorking applicationWorking = new ApplicationWorking();
        //Method to switch between various functions of the application based on the userchoice
        public void appFunctions(List<Product> productList, string userChoice)
        {
            switch (userChoice.ToUpper())
            {
                //Add New Product Information
                case "A":
                    applicationWorking.ProductAddition(productList);
                    break;
                //Search for Specific Product Information
                case "S":
                    applicationWorking.ProductSearch(productList);
                    break;
                //Delete the Specific Product Information
                case "D":
                    applicationWorking.ProductDeletion(productList);
                    break;
                //Modify the Product Information
                case "M":
                    applicationWorking.ProductModification(productList);
                    break;
                //View all the Product Names in the Product List
                case "V":
                    applicationWorking.ProductView(productList);
                    break;
                //Sort the Products in the List according to Name or ID
                case "Q":
                    applicationWorking.ProductSort(productList);
                    break;
                default:
                    Console.WriteLine("The Provided input is invalid !!");
                    break;
            }
        }
    }
}