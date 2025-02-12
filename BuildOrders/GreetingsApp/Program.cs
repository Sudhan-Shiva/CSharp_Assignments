using Pastel;
using MathApp;

public class Program
{
    /// <summary>
    /// The primary Main method which acts as the entrypoint of the project
    /// </summary>
    static void Main()
    {
        Console.WriteLine($"WELCOME TO THE APPLICATION !!!".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nProvide two integer inputs to do the math operations.".Pastel(ConsoleColor.Magenta));

        OperationsManager mathOperations = new OperationsManager();

        mathOperations.DoMathOperations();

        Console.WriteLine($"\nPress any key to exit.....".Pastel(ConsoleColor.Magenta));
        Console.ReadKey();
    }
}