using ContactManager.DisplayInformation;

namespace ContactManager.ValidInput
{
    /// <summary>
    /// Prompts the user for a valid input format
    /// </summary>
    public class GetValidInput
    {
        DataValidation dataValidation = new DataValidation();
        /// <summary>
        /// Check whether the given string for the Phone number is according to the Phone number format
        /// </summary>
        /// <param name="inputNumber">Given as an input for the phone number</param>
        /// <returns>Returns the proper phone number</returns>
        public long GetValidPhoneNumber(string inputPhoneNumber)
        {
            while (!dataValidation.IsPhoneNumberValid(inputPhoneNumber))
            {
                PrintMessages.PrintInvalidInput();
                inputPhoneNumber = Console.ReadLine();
            }

            return long.Parse(inputPhoneNumber);
        }
        /// <summary>
        /// Check whether the given string for the Phone number is according to the Phone number format
        /// </summary>
        /// <param name="inputNumber">Given as an input for the phone number</param>
        /// <returns>Returns the proper email</returns>
        public string GetValidEmail(string inputEmail)
        {
            while (!dataValidation.IsEmailValid(inputEmail))
            {
                PrintMessages.PrintInvalidInput();
                inputEmail = Console.ReadLine();
            }

            return inputEmail;
        }
    }
}
