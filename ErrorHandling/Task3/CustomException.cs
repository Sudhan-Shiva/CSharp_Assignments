/// <summary>
/// Handle the CustomException 'InvalidUserInputException'
/// </summary>
public class CustomException
{
    /// <summary>
    /// Print appropriate messages for 'InvalidUserInputException' Exception.
    /// </summary>
    public void ExecuteTask3()
    {
        var testArray = new int[3];
        int count = 0;

        try
        {
            while (count < 3)
            {
                Console.Write($"Type the input element at index {count} : ");
                testArray[count] = returnInt(Console.ReadLine());
                count++;
            }

            Console.WriteLine("\nThe array has been successfully created");
        }

        catch (InvalidUserInputException invaliduserInputException)
        {
            try
            {
                throw new Exception(invaliduserInputException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\nThe array only allows input that can be parsed to a valid integer.\nException Occured : {exception.Message}");
            }
        }

        finally
        {
            Console.WriteLine("\nThe block has been executed.");
        }
    }

    private int returnInt(string userInput)
    {
        if (int.TryParse(userInput, out int result))
        {
            return int.Parse(userInput);
        }

        throw new InvalidUserInputException($"The user input '{userInput}' is in invalid format and cannot be parsed to an integer.");
    }
}

/// <summary>
/// Define Custom Exception 'InvalidUserInputException'
/// </summary>
public class InvalidUserInputException : Exception
{
    public InvalidUserInputException(string exceptionMessage) : base(exceptionMessage)
    {

    }

}

