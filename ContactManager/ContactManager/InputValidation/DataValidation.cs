namespace ContactManager.InputValidation
{
    /// <summary>
    /// Validates the given input format
    /// </summary>
    public class DataValidation
    {
        /// <summary>
        /// Check whether the given string for the Phone number is according to the Phone number format
        /// </summary>
        /// <param name="inputNumber">Given as an input for the phone number</param>
        /// <returns>returns a boolean variable representing whether the given input is in the phone number format</returns>
        public bool IsPhoneNumberValid(string inputNumber)
        {
            return long.TryParse(inputNumber, out long parsedNumber);  
        }

        //Method to validate whether the given email is of the proper format
        /// <summary>
        /// Check whether the given string for the Email is according to the email format
        /// </summary>
        /// <param name="inputEmail">Given as an input for the email</param>
        /// <returns>returns a boolean variable representing whether the given input is in the email format</returns>
        public bool IsEmailValid(string inputEmail)
        {
            return inputEmail.Contains("@") && inputEmail.Contains(".com");
        }
    }
}
