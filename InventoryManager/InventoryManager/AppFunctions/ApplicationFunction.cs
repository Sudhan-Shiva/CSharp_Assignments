namespace InventoryManager.AppFunctions
{
    public class ApplicationFunction
    {
        //Create the required object references 
        

        ProductManager productManager = new ProductManager();
        //Method to switch between various functions of the application based on the userchoice
        public void appFunctions(string userChoice)
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