using MathFunctions.Utility;

public class Program
{
    static void Main()
    {
        MathUtils mathUtils = new MathUtils();

        Console.Write("Provide the First integer : ");
        int firstIntegerInput = int.Parse(Console.ReadLine());

        Console.Write("Provide the Second integer : ");
        int secondIntegerInput = int.Parse(Console.ReadLine());

        Console.WriteLine($"The result of addition between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Add(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"The result of subtraction between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Subtract(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"The result of multiplication between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Multiply(firstIntegerInput, secondIntegerInput)}.");
        Console.WriteLine($"The result of division between {firstIntegerInput} and {secondIntegerInput} is equal to {mathUtils.Divide(firstIntegerInput, secondIntegerInput)}.");

        Console.ReadKey();
    }
}