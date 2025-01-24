using ConsoleTables;
using InventoryManager.Model;
using InventoryManager.ValidInput;

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
        public string GetUserOptions()
        {
            Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[Q]uickSort the Product List\n[D]elete the Product\n[E]xit the Product List\n");
            Console.Write("Type your Choice: ");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }
        /// <summary>
        /// To get another input when the given input is already present
        /// </summary>
        /// <returns>The input for replacing the present input</returns>
        public string GetUniqueInput()
        {
            Console.Write("The Product Field is Already Present !\nGive a new Field : ");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get unique inputs for the product name and ID
        /// </summary>
        /// <param name="inputParameter">The input which is checked</param>
        /// <param name="isProductName">Represents whether the given input is the product name</param>
        /// <returns>A unique input for the product name or ID</returns>
        public string GetDistinctInputs(string inputParameter, int inputIndex)
        {
            while (inputIndex != -1)
            {
                inputParameter = GetUniqueInput();
            }
            return inputParameter;
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
        public string ReplaceEmptyInput()
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
        public string GetProductId()
        {
            Console.Write("Enter the Product ID :  ");
            string productId = Console.ReadLine();
            return GetValidInput(productId);
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
        public string GetEditField()
        {
            Console.WriteLine("Choose the Information that must be edited : \n [N]ame of the Product \n [I]D of the Product \n [P]rice of the Product \n [Q]uantity of the product \n");
            Console.Write("Type your Choice: ");
            string editField = Console.ReadLine();
            return editField;
        }

        /// <summary>
        /// To get the field(Name/ID) according to whcih the action must be performed
        /// </summary>
        /// <returns>String representing the field</returns>
        public string GetActionField()
        {
            Console.Write("Perform the action by Name or ID ?\n[N]ame/[I]d :");
            string sortOrder = Console.ReadLine();
            return sortOrder;
        }

        /// <summary>
        /// To get a valid input which is not null or empty string
        /// </summary>
        /// <param name="inputParameter">The input that is validated</param>
        /// <returns>A valid input which is not null or empty string</returns>
        public string GetValidInput(string inputParameter)
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
        public int GetValidInteger(string inputParameter)
        {
            while (!dataValidation.IsDataValid(inputParameter))
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
        public decimal GetValidDecimal(string inputParameter)
        {
            while (!dataValidation.IsProductPriceValid(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            decimal.TryParse(inputParameter, out decimal validData);
            return validData;
        }
    }
}
