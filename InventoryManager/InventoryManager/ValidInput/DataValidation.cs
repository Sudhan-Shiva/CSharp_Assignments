using InventoryManager.PrintInformation;

namespace InventoryManager.ValidInput
{
    public class DataValidation
    {
        //Method to validate whether the given input is a integer
        public int IsDataValid(string inputProductField)
        {
            //Use TryParse to check whether the given input can be converted to a valid integer
            int parsedField;
            //Loop until a valid input is given by the user
            while (!int.TryParse(inputProductField, out parsedField))
            {
                InputManager.PrintInvalidInput();
                inputProductField = Console.ReadLine();
            }
            //Return the valid output
            return parsedField;
        }

        //Method to validate whether the given input is a decimal
        public decimal IsProductPriceValid(string inputProductPrice)
        {
            //Use TryParse to check whether the given input can be converted to a valid decimal
            decimal parsedPrice;
            //Loop until a valid input is given by the user
            while (!decimal.TryParse(inputProductPrice, out parsedPrice))
            {
                InputManager.PrintInvalidInput();
                inputProductPrice = Console.ReadLine();
            }
            //Return the valid output
            return parsedPrice;
        }

    }
}



