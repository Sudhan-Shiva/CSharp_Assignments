using DisplayApp;
using OperationsApp;

namespace MathApp
{
    /// <summary>
    /// Class to manage the math operations
    /// </summary>
    public class OperationsManager
    {
        /// <summary>
        /// Method to perform the required math operations
        /// </summary>
        public void DoMathOperations()
        {
            MathUtils mathUtils = new MathUtils();

            int firstInput = ConsoleUI.GetInputInteger();
            int secondInput = ConsoleUI.GetInputInteger();

            switch ((MathOperations) ConsoleUI.GetUserOptions())
            {
                case MathOperations.Addition:
                    ConsoleUI.PrintAdditionResult(firstInput, secondInput, mathUtils.Add(firstInput, secondInput));
                    break;
                case MathOperations.Subtraction:
                    ConsoleUI.PrintSubtractionResult(firstInput, secondInput, mathUtils.Subtract(firstInput, secondInput));
                    break;
                case MathOperations.Multiplication:
                    ConsoleUI.PrintMultiplicationResult(firstInput, secondInput, mathUtils.Multiply(firstInput, secondInput));
                    break;
                case MathOperations.Division:
                    if (secondInput == 0)
                        secondInput = ConsoleUI.GetDifferentInputIntegerInCaseOfDivideByZeroException();
                    ConsoleUI.PrintDivisionResult(firstInput, secondInput, mathUtils.Divide(firstInput, secondInput));
                    break;
                default:
                    Console.WriteLine("\nThe given input is invalid !!!");
                    Console.WriteLine("\n------EXITING-------");
                    break;
            }
        }
    }
}
