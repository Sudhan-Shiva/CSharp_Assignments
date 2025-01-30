using InventoryManager.InputValidation;
using InventoryManager.Model;

namespace InventoryManager.UserInterface
{
    /// <summary>
    /// Represents all the input methods
    /// </summary>
    public class InputManager
    {
        DataValidation dataValidation;
        public InputManager(DataValidation mainDataValidation) 
        {
            dataValidation = mainDataValidation;
        }

        /// <summary>
        /// To get the user option
        /// </summary>
        /// <returns>The user choice</returns>
        public int GetUserOptions()
        {
            Console.Write($"\nHello!\nWhat do you want to do?\n[0] {ApplicationOptions.ViewProducts}\n[1] {ApplicationOptions.AddProduct}\n[2] {ApplicationOptions.DeleteProduct}\n[3] {ApplicationOptions.EditProduct}\n[4] {ApplicationOptions.SearchProduct}\n[5] {ApplicationOptions.SortProducts}\n[6] {ApplicationOptions.Exit}\nType your Choice: ");
            return GetChoiceWithinBounds(6);
        }

        /// <summary>
        /// To get another input when the given input is already present
        /// </summary>
        /// <returns>The input for replacing the present input</returns>
        public string GetUniqueProductName()
        {
            Console.Write("The Product Name is Already Present !\nGive a new Product name : ");
            string inputProductName = Console.ReadLine();
            return inputProductName;
        }

        /// <summary>
        /// To get another input when the given input is already present
        /// </summary>
        /// <returns>The input for replacing the present input</returns>
        public int GetUniqueProductId()
        {
            Console.Write("The Product ID is Already Present !\nGive a new Product ID : ");
            int inputProductId = GetValidInteger(Console.ReadLine());
            return inputProductId;
        }

        /// <summary>
        /// To get another input when the given input is invalid
        /// </summary>
        /// <returns>The input for replacing the invalid input</returns>
        public string ReplaceInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get another input when the given input is null or empty string
        /// </summary>
        /// <returns>The input for replacing the null or empty string input</returns>
        private string ReplaceEmptyInput()
        {
            Console.Write("The Provided input is empty !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get the product name
        /// </summary>
        /// <returns>The name of the product</returns>
        public string GetProductName()
        {
            Console.Write("Enter the Product Name :  ");
            string productName = Console.ReadLine();
            return GetValidInput(productName);
        }

        /// <summary>
        /// To get the product ID
        /// </summary>
        /// <returns>The ID of the product</returns>
        public int GetProductId()
        {
            Console.Write("Enter the Product ID :  ");
            string productId = Console.ReadLine();
            return GetValidInteger(GetValidInput(productId));
        }

        /// <summary>
        /// To get the price of the product
        /// </summary>
        /// <returns>The price of the product</returns>
        public decimal GetProductPrice()
        {
            Console.Write("Enter the Product Price :  ");
            string productPrice = Console.ReadLine();
            return GetValidDecimal(productPrice);
        }

        /// <summary>
        /// To get the product quantity
        /// </summary>
        /// <returns>The product quantity</returns>
        public int GetProductQuantity()
        {
            Console.Write("Enter the Product Quantity :  ");
            string productQuantity = Console.ReadLine();
            return GetValidInteger(productQuantity);
        }

        /// <summary>
        /// To get the Editing field(Name/ID/Quantity/price) in the product
        /// </summary>
        /// <returns>String representing the field that must be edited</returns>
        public int GetEditField()
        {
            Console.Write($"Choose the Information that must be edited : \n[0] {UserEditChoice.EditProductName}\n[1] {UserEditChoice.EditProductId}\n[2] {UserEditChoice.EditProductPrice}\n[3] {UserEditChoice.EditProductQuantity} \nType your Choice: ");
            return GetChoiceWithinBounds(3);
        }

        private int GetChoiceWithinBounds(int maxEnumLength)
        {
            int enumChoice = GetValidInteger(Console.ReadLine());
            while (enumChoice < 0 || enumChoice > maxEnumLength)
            {
                enumChoice = GetValidInteger(ReplaceInvalidInput());
            }
            return enumChoice;
        }
        /// <summary>
        /// To get the field(Name/ID) according to whcih the action must be performed
        /// </summary>
        /// <returns>String representing the field</returns>
        public int GetActionField()
        {
            Console.Write($"[0] {NameOrIdChoice.ByName}\n[1] {NameOrIdChoice.ById}\nPerform the action by Name or ID : ");
            return GetChoiceWithinBounds(1);
        }

        /// <summary>
        /// To get a valid input which is not null or empty string
        /// </summary>
        /// <param name="inputParameter">The input that is validated</param>
        /// <returns>A valid input which is not null or empty string</returns>
        private string GetValidInput(string inputParameter)
        {
            while (dataValidation.IsDataEmpty(inputParameter))
            {
                inputParameter = ReplaceEmptyInput();
            }
            return inputParameter;
        }

        /// <summary>
        /// To get a valid input which is of the required datatype integer.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is integer</returns>
        private int GetValidInteger(string inputParameter)
        {
            while (!dataValidation.IsDataInt(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }

        /// <summary>
        /// To get a valid input which is of the required datatype decimal.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is decimal</returns>
        private decimal GetValidDecimal(string inputParameter)
        {
            while (!dataValidation.IsInputDecimal(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            decimal.TryParse(inputParameter, out decimal validData);
            return validData;
        }
    }
}
