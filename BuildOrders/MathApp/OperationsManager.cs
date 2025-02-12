using DisplayApp;
using OperationsApp;

namespace MathApp
{
    public class OperationsManager
    {
        public void DoMathOperations()
        {
            MathUtils mathUtils = new MathUtils();

            int firstInput = ConsoleUI.GetInteger();
            int secondInput = ConsoleUI.GetInteger();

            switch (InputManager.GetInputOperation())
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
