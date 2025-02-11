using Pastel;
using MathApp;

public class Program
{
    static void Main()
    {
        Console.WriteLine($"WELCOME TO THE APPLICATION !!!".Pastel(ConsoleColor.Magenta));

        MathOperations mathOperations = new MathOperations();

        mathOperations.DoMathOperations();

        Console.ReadKey();
    }
}