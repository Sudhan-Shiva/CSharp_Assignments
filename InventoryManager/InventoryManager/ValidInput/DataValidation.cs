namespace InventoryManager.ValidInput
{
    public class DataValidation
    {
        //Method to validate whether the given input is a integer
        public bool IsDataValid(string inputProductField)
        {
            return int.TryParse(inputProductField, out int parsedField);
        }

        //Method to validate whether the given input is a decimal
        public bool IsProductPriceValid(string inputProductPrice)
        {
            return decimal.TryParse(inputProductPrice, out decimal parsedPrice);
        }

    }
}