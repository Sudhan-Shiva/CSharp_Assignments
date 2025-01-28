using InventoryManager.UserInterface;
using InventoryManager.Model;

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
        public int AppFunctions(int userChoice)
        {
            ApplicationOptions applicationOptions = (ApplicationOptions) userChoice;
            switch (applicationOptions)
            {
                case ApplicationOptions.AddProduct :
                    productManager.AddProduct();
                    break;
                case ApplicationOptions.SearchProduct :
                    productManager.SearchProduct();
                    break;
                case ApplicationOptions.DeleteProduct :
                    productManager.DeleteProduct();
                    break;
                case ApplicationOptions.EditProduct :
                    productManager.ModifyProduct();
                    break;
                case ApplicationOptions.ViewProducts :
                    productManager.ViewProduct();
                    break;
                case ApplicationOptions.SortProducts :
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
