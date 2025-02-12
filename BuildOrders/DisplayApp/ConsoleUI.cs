using UtilityApp;
using Pastel;

namespace DisplayApp
{
    /// <summary>
    /// Defines the Input methods and Print methods
    /// </summary>
    public static class ConsoleUI
    {
        /// <summary>
        /// Method to print the available user options and get the corresponding integer to perform operations 
        /// </summary>
        /// <returns>The corresponding integer to perform operations</returns>
        public static int GetUserOptions()
        {
            Console.WriteLine("[0] Addition");
            Console.WriteLine("[1] Subtraction");
            Console.WriteLine("[2] Multiplication");
            Console.WriteLine("[3] Division");
            Console.Write("\nBased on the above inputs, select the operation to be performed : ");
            return DataValidation.GetChoiceWithinBounds(DataValidation.GetValidInteger(Console.ReadLine()), 3);
        }

        /// <summary>
        /// Method to get an input integer
        /// </summary>
        /// <returns>The input integer</returns>
        public static int GetInputInteger()
        {
            Console.Write($"\nProvide the Input integer : ".Pastel(ConsoleColor.Yellow));
            return DataValidation.GetValidInteger(Console.ReadLine());
        }

        /// <summary>
        /// Method to get an different input integer in case of DivideByZeroException
        /// </summary>
        /// <returns>The input integer which is not equal to zero</returns>
        public static int GetDifferentInputIntegerInCaseOfDivideByZeroException()
        {
            Console.WriteLine("\nA number cannot be divided by zero !!!!".Pastel(ConsoleColor.Red));
            Console.Write($"\nProvide a different input integer : ".Pastel(ConsoleColor.Yellow));
            int inputInteger = DataValidation.GetValidInteger(Console.ReadLine());
            while (inputInteger == 0)
                inputInteger = GetDifferentInputIntegerInCaseOfDivideByZeroException();
            return inputInteger;
        }

        /// <summary>
        /// Method to print the result of the addition process
        /// </summary>
        /// <param name="firstIntegerInput">First input of the process</param>
        /// <param name="secondIntegerInput">Second input of the process</param>
        /// <param name="result">The result of the operation</param>
        public static void PrintAdditionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of addition between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }

        /// <summary>
        /// Method to print the result of the Subtraction process
        /// </summary>
        /// <param name="firstIntegerInput">First input of the process</param>
        /// <param name="secondIntegerInput">Second input of the process</param>
        /// <param name="result">The result of the operation</param>
        public static void PrintSubtractionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of subtraction between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }

        /// <summary>
        /// Method to print the result of the Multiplication process
        /// </summary>
        /// <param name="firstIntegerInput">First input of the process</param>
        /// <param name="secondIntegerInput">Second input of the process</param>
        /// <param name="result">The result of the operation</param>
        public static void PrintMultiplicationResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of multiplication between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }

        /// <summary>
        /// Method to print the result of the Division process
        /// </summary>
        /// <param name="firstIntegerInput">First input of the process</param>
        /// <param name="secondIntegerInput">Second input of the process</param>
        /// <param name="result">The result of the operation</param>
        public static void PrintDivisionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of division between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }
    }
}
