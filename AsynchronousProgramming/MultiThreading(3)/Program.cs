/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    private static long _factorialResult { get; set; }
    private static long _cubesSumResult { get; set; }

    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(CalculateFactorial));
        Thread thread2 = new Thread(new ThreadStart(CalculateCubesSum));
        thread1.Start();
        thread2.Start();

        //Main thread is blocked until thread1 & thread2 completes
        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Combined Result : Factorial = {_factorialResult}, CubesSum = {_cubesSumResult}");
        Console.ReadKey();
    }

    /// <summary>
    /// To calculate the factorial
    /// </summary>
    static void CalculateFactorial()
    {
        long result = 1;
        for(int i = 1; i <= 20; i++)
        {
            result *= i;
        }

        _factorialResult = result;
        Console.WriteLine("Resulting Factorial : "+result);
    }

    /// <summary>
    /// To calculate the sum of cubes
    /// </summary>
    static void CalculateCubesSum()
    {
        long result = 0;
        for (int i = 1; i <= 1000; i++)
        {
            result += (i * i * i);
        }

        _cubesSumResult = result;
        Console.WriteLine("Resulting Cube Sum : " + result);
    }
}
