namespace MathApp
{
    /// <summary>
    /// Defines the required methods
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="firstInput">The first integer input</param>
        /// <param name="secondInput">The second integer input</param>
        /// <returns>The addition result of the two integer inputs</returns>
        public int Add(int firstInput, int secondInput) => firstInput + secondInput;

        /// <summary>
        /// Subtracts two numbers
        /// </summary>
        /// <param name="firstInput">The first integer input</param>
        /// <param name="secondInput">The second integer input</param>
        /// <returns>The subtraction result of the two integer inputs</returns>
        public int Subtract(int firstInput, int secondInput) => firstInput - secondInput;

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="firstInput">The first integer input</param>
        /// <param name="secondInput">The second integer input</param>
        /// <returns>The multiplication result of the two integer inputs</returns>
        public int Multiply(int firstInput, int secondInput) => firstInput * secondInput;

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="firstInput">The first integer input</param>
        /// <param name="secondInput">The second integer input</param>
        /// <returns>The division result of the two integer inputs</returns>
        public int Divide(int firstInput, int secondInput) => firstInput / secondInput;
    }
}
