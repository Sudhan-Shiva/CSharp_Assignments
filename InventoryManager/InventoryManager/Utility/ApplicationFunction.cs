using InventoryManager.UserInterface;

namespace InventoryManager.Utility
{
    /// <summary>
    /// Represents the functions of the application based on the userchoice
    /// </summary>
    public class ApplicationFunction
    {
        /// <summary>
        /// The ProductManager required to handle the operations of the product list
        /// </summary>
        ProductManager productManager;

        /// <summary>
        /// Represents the necessary object references to the class
        /// </summary>
        /// <param name="mainProductManager">Required object reference</param>
        public ApplicationFunction(ProductManager mainProductManager)
        {
            productManager = mainProductManager;
        }

        /// <summary>
        /// To switch between various functions of the application based on the userchoice
        /// </summary>
        /// <param name="userChoice">The input based on which the functions are switched</param>
        public string AppFunctions(string userChoice)
        {
            switch (userChoice.ToUpper())
            {
                case "A":
                    productManager.AddProduct();
                    break;
                case "S":
                    productManager.SearchProduct();
                    break;
                case "D":
                    productManager.DeleteProduct();
                    break;
                case "M":
                    productManager.ModifyProduct();
                    break;
                case "V":
                    productManager.ViewProduct();
                    break;
                case "Q":
                    productManager.SortProduct();
                    break;
                default:
                    OutputManager.PrintInvalidInput();
                    break;
            }
            return userChoice;
        }
    }
}
