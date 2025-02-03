/// <summary>
/// Handle the DivideByZeroException
/// </summary>
public class DividingByZeroException
{
    /// <summary>
    /// Print appropriate messages for DivideByZero Exception.
    /// </summary>
    public void ExecuteTask1()
    {
        Console.Write("Enter the first input :");
        int firstInput = int.Parse(Console.ReadLine());
        Console.Write("Enter the second input :");
        int secondInput = int.Parse(Console.ReadLine());

        try
        {
            var division = divideTwoNumbers(firstInput, secondInput);
            Console.WriteLine("\nDivision process has been successfully executed .");
            Console.WriteLine($"The output of the division process is  {division}");
        }

        catch (System.DivideByZeroException exception)
        {
            Console.WriteLine("\nDivision by zero is invalid.");
            Console.WriteLine($"Exception Occured : {exception.Message}");
        }
        finally
        {
            Console.WriteLine("\nThe block has been executed.");
        }
    }

    /// <summary>
    /// Throw the exception
    /// </summary>
    /// <param name="firstNumber">Operand of the Division Operation/param>
    /// <param name="secondNumber">Operand of the Division Operation</param>
    /// <returns>Result of the operation</returns>
    private double divideTwoNumbers(int firstNumber, int secondNumber)
    {
        return firstNumber / secondNumber;
    }
}