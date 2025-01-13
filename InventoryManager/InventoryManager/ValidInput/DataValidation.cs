using InventoryManager.PrintInformation;

namespace InventoryManager.ValidInput
{
    public class DataValidation
    {
        //Method to validate whether the given input is a integer
        public int CheckDataIsInt(string inputProductField)
        {
            //Use TryParse to check whether the given input can be converted to a valid integer
            bool isProductFieldInt = int.TryParse(inputProductField, out int parsedField);
            //Loop until a valid input is given by the user
            while (!isProductFieldInt)
            {
                PrintMessages.PrintInvalidInput();
                isProductFieldInt = int.TryParse(Console.ReadLine(), out parsedField);
            }
            //Return the valid output
            return parsedField;
        }

        //Method to validate whether the given input is a decimal
        public decimal CheckProductPrice(string inputProductPrice)
        {
            //Use TryParse to check whether the given input can be converted to a valid decimal
            bool isProductPriceDecimal = decimal.TryParse(inputProductPrice, out decimal parsedPrice);
            //Loop until a valid input is given by the user
            while (!isProductPriceDecimal)
            {
                PrintMessages.PrintInvalidInput();
                isProductPriceDecimal = decimal.TryParse(Console.ReadLine(), out parsedPrice);
            }
            //Return the valid output
            return parsedPrice;
        }

    }
}



