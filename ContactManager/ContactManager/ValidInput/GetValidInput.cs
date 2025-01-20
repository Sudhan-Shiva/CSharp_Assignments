using ContactManager.DisplayMenuInformation;

namespace ContactManager.ValidInput
{
    public class GetValidInput
    {
        DataValidation dataValidation = new DataValidation();
        
        public long GetValidPhoneNumber(string inputPhoneNumber)
        {
            //Loop until a valid phone number is given by the user
            while (!dataValidation.IsPhoneNumberValid(inputPhoneNumber))
            {
                PrintMessages.PrintInvalidInput();
                inputPhoneNumber = Console.ReadLine();
            }

            long.TryParse(inputPhoneNumber, out long parsedPhoneNumber);
            return parsedPhoneNumber;
        }

        public string GetValidEmail(string inputEmail)
        {
            //Loop until a valid email is given by the user
            while (!dataValidation.IsEmailValid(inputEmail))
            {
                PrintMessages.PrintInvalidInput();
                inputEmail = Console.ReadLine();
            }

            return inputEmail;
        }
    }
}
