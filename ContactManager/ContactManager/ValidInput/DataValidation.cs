using ContactManager.DisplayInformation;

namespace ContactManager.ValidInput
{
    public class DataValidation
    {
        //Method to Check whether the given string for the Phone number can be formatted to the Phone number format
        public bool IsPhoneNumberValid(string inputNumber)
        {
            //Use TryParse to check whether the given input can be converted to a valid long
            return long.TryParse(inputNumber, out long parsedNumber);  
        }

        //Method to validate whether the given email is of the proper format
        public bool IsEmailValid(string inputEmail)
        {
            return inputEmail.Contains("@") && inputEmail.Contains(".com");
        }
    }
}
