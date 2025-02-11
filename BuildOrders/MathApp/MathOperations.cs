using DisplayApp;

namespace MathApp
{
    public class MathOperations
    {
        public void DoMathOperations()
        {
            MathUtils mathUtils = new MathUtils();

            int firstInput = ConsoleUI.GetInteger();
            int secondInput = ConsoleUI.GetInteger();

            ConsoleUI.PrintAdditionResult(firstInput, secondInput, mathUtils.Add(firstInput,secondInput));
            ConsoleUI.PrintSubtractionResult(firstInput, secondInput, mathUtils.Subtract(firstInput,secondInput));
            ConsoleUI.PrintMultiplicationResult(firstInput, secondInput, mathUtils.Multiply(firstInput,secondInput));
            ConsoleUI.PrintDivisionResult(firstInput, secondInput, mathUtils.Divide(firstInput,secondInput));
        }
    }
}
