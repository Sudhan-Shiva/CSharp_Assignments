using UtilityApp;
using Pastel;

namespace DisplayApp
{
    public static class ConsoleUI
    {

        public static int GetUserOptions()
        {
            Console.WriteLine("[0] Addition");
            Console.WriteLine("[1] Subtraction");
            Console.WriteLine("[2] Multiplication");
            Console.WriteLine("[3] Division");
            Console.Write("\nBased on the above inputs, select the operation to be performed : ");
            return DataValidation.GetChoiceWithinBounds(DataValidation.GetValidInteger(Console.ReadLine()), 3);
        }
        public static int GetInteger()
        {
            Console.Write($"\nProvide the Input integer : ".Pastel(ConsoleColor.Yellow));
            return DataValidation.GetValidInteger(Console.ReadLine());
        }

        public static void PrintAdditionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of addition between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }

        public static void PrintSubtractionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of subtraction between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }
        public static void PrintMultiplicationResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of multiplication between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }
        public static void PrintDivisionResult(int firstIntegerInput, int secondIntegerInput, int result)
        {
            Console.WriteLine($"\nThe result of division between {$"{firstIntegerInput}".Pastel(ConsoleColor.Red)} and {$"{secondIntegerInput}".Pastel(ConsoleColor.Red)} is equal to {$"{result}".Pastel(ConsoleColor.Red)}.");
        }
    }
}
