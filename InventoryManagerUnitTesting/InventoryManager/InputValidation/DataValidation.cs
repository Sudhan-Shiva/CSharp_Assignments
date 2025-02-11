namespace InventoryManager.InputValidation
{
    public class DataValidation
    {
        /// <summary>
        /// To validate whether the given input is a integer
        /// </summary>
        /// <param name="inputProductField">The input that must be checked</param>
        /// <returns>True if the input can be parsed to an integer,else false</returns>
        public bool IsDataInt(string inputProductField)
        {
            return int.TryParse(inputProductField, out int parsedField);
        }

        /// <summary>
        /// To validate whether the given input for the product price is a decimal
        /// </summary>
        /// <param name="inputProductPrice">The input that must be checked</param>
        /// <returns>True if the input can be parsed to a decimal, else false</returns>
        public bool IsInputDecimal(string inputProductPrice)
        {
            return decimal.TryParse(inputProductPrice, out decimal parsedPrice);
        }

        /// <summary>
        /// To check whether the given input is null or empty string
        /// </summary>
        /// <param name="inputProductField">The input that must be checked</param>
        /// <returns>True if the input is null or empty string, else false</returns>
        public bool IsDataEmpty(string inputProductField)
        {
            return (inputProductField == null || inputProductField == "");
        }
    }
}
