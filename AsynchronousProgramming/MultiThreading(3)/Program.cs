public class Program
{
    static long factorialResult = 0;
    static long cubesSumResult = 0;

    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(CalculateFactorial));
        Thread thread2 = new Thread(new ThreadStart(CalculateCubesSum));
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Console.WriteLine($"Combined Result : Factorial = {factorialResult}, CubesSum = {cubesSumResult}");
        Console.ReadKey();
    }

    static void CalculateFactorial()
    {
        long result = 1;
        for(int i = 1; i <= 20; i++)
        {
            result *= i;
        }
        factorialResult = result;
        Console.WriteLine("Resulting Factorial : "+result);
    }

    static void CalculateCubesSum()
    {
        long result = 0;
        for (int i = 1; i <= 1000; i++)
        {
            result += (i * i * i);
        }
        cubesSumResult = result;
        Console.WriteLine("Resulting Cube Sum : " + result);
    }
}