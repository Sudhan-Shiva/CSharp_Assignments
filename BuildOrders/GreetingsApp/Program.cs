using Pastel;
using MathApp;

public class Program
{
    static void Main()
    {
        Console.WriteLine($"WELCOME TO THE APPLICATION !!!".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nProvide two integer inputs to do the math operations.".Pastel(ConsoleColor.Magenta));

        MathOperations mathOperations = new MathOperations();

        mathOperations.DoMathOperations();

        Console.ReadKey();
    }
}