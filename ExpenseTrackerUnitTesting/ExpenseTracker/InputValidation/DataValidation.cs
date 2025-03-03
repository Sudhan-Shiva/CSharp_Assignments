namespace ExpenseTracker.InputValidation
{
    /// <summary>
    /// To validate the input data
    /// </summary>
    public class DataValidation
    {
        /// <summary>
        /// To show whether the input can be parsed to an integer
        /// </summary>
        /// <param name="inputField">The input that must be validated</param>
        /// <returns>True if the input can be parsed to an integer, else false</returns>
        public bool IsInputInt(string inputField)
        {
            return int.TryParse(inputField, out int parsedAmount);
        }

        /// <summary>
        /// To show whether the input can be parsed to an DateOnly
        /// </summary>
        /// <param name="inputField">The input that must be validated</param>
        /// <returns>True if the input can be parsed to an DateOnly, else false</returns>
        public bool IsInputDate(string inputField)
        {
            return DateOnly.TryParse(inputField, out DateOnly parsedDate);
        }

        /// <summary>
        /// To check whether the given input is null or empty string
        /// </summary>
        /// <param name="inputProductField">The input that must be checked</param>
        /// <returns>True if the input is null or empty string, else false</returns>
        public virtual bool IsDataEmpty(string inputProductField)
        {
            return (inputProductField == null || inputProductField == "");
        }
    }
}
