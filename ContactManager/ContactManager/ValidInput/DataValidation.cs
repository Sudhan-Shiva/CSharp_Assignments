using ContactManager.DisplayMenuInformation;

namespace ContactManager.ValidInput
{
    public class DataValidation
    {
        //Method to Check whether the given string for the Phone number can be formatted to the Phone number format
        public long CheckPhoneNumber(string inputNumber)
        {
            //Use TryParse to check whether the given input can be converted to a valid long
            bool isPhoneNumberFormat = long.TryParse(inputNumber, out long parsedNumber);
            //Loop until a valid input is given by the user
            while (!isPhoneNumberFormat)
            {
                PrintMessages.PrintInvalidInput();
                isPhoneNumberFormat = long.TryParse(Console.ReadLine(), out parsedNumber);
            }
            //Return the valid output
            return parsedNumber;
        }

        //Method to validate whether the given email is of the proper format
        public string CheckProperEmail(string inputEmail)
        {
            //Use Contains to check whether the given email contains "@' and ".com"
            bool isEmailValid = inputEmail.Contains("@") && inputEmail.Contains(".com");
            //Loop until a valid input is given by the user
            while (!isEmailValid)
            {
                PrintMessages.PrintInvalidInput();
                inputEmail = Console.ReadLine();
                isEmailValid = inputEmail.Contains("@") && inputEmail.Contains(".com");
            }
            //Return the valid output
            return inputEmail;
        }
    }
}
