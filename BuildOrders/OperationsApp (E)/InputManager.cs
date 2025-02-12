using DisplayApp;

namespace OperationsApp
{
    public static class InputManager
    {
        public static MathOperations GetInputOperation()
        {
            MathOperations inputOperation = (MathOperations) ConsoleUI.GetUserOptions();
            return inputOperation;
        }
    }
}
