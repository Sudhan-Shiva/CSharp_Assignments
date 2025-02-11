using MathApp;
using Pastel;

public class Program
{
    static void Main()
    {
        Console.WriteLine($"WELCOME TO THE APPLICATION !!!".Pastel(ConsoleColor.Magenta));

        MathUtils mathUtils = new MathUtils();

        Console.Write($"\nProvide the First integer : ".Pastel(ConsoleColor.Yellow));
        int firstIntegerInput = int.Parse(Console.ReadLine());

        Console.Write($"\nProvide the Second integer : ".Pastel(ConsoleColor.Yellow));
        int secondIntegerInput = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nThe result of addition between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Add(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"\nThe result of subtraction between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Subtract(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"\nThe result of multiplication between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Multiply(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"\nThe result of division between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Divide(firstIntegerInput, secondIntegerInput)}.");

        Console.ReadKey();
    }
}