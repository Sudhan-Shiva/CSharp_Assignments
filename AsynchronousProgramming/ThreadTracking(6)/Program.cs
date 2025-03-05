using System.Diagnostics;
using Pastel;

/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static async Task Main()
    {
        Console.WriteLine("Running with ConfigureAwait(false)....".Pastel(ConsoleColor.Magenta));
        Console.WriteLine("Main Thread ID : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        var result = await MethodB();
        Console.WriteLine("Main Thread ID at the completion : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Result : ".Pastel(ConsoleColor.Yellow) +result);

        Console.WriteLine();

        Console.WriteLine("Default process....".Pastel(ConsoleColor.Magenta));
        Console.WriteLine("Main Thread ID : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        var result2 = await MethodBWithSameContext();
        Console.WriteLine("Main Thread ID at the completion : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Result : ".Pastel(ConsoleColor.Yellow) + result2);

        Console.ReadKey();
    }

    /// <summary>
    /// To simulate performing a complex calculation which runs on a different context if awaited.
    /// </summary>
    /// <returns>The result of the complex calculation</returns>
    static async Task<int> MethodA()
    {
        Console.WriteLine("Thread ID Before Delay : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        int result = 0;
        for (int i = 1; i <= 100; i++)
        {
            result += (i * i);
        }

        await Task.Delay(1000).ConfigureAwait(false);
        Console.WriteLine("Thread ID After delay : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        return result;
    }

    /// <summary>
    /// To simulate further calculation of data from another method
    /// </summary>
    /// <returns>The final result after calculations</returns>
    static async Task<int> MethodB()
    {
        Console.WriteLine("Thread ID Before Calling MethodA : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        int result = await MethodA();
        for (int i = 101; i <= 200; i++)
        {
            result += (i * i);
        }

        Console.WriteLine("Thread ID After Calling MethodA : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        return result;
    }

    /// <summary>
    /// To simulate performing a complex calculation which runs on the same context if awaited.
    /// </summary>
    /// <returns>The result of the complex calculation</returns>
    static async Task<int> MethodAWithSameContext()
    {
        Console.WriteLine("Thread ID Before Delay : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        int result = 0;
        for (int i = 1; i <= 100; i++)
        {
            result += (i * i);
        }

        await Task.Delay(1000);
        Console.WriteLine("Thread ID After delay : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        return result;
    }

    /// <summary>
    /// To simulate further calculation of data from another method
    /// </summary>
    /// <returns>The final result after calculations</returns>
    static async Task<int> MethodBWithSameContext()
    {
        Console.WriteLine("Thread ID Before Calling MethodA : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        int result = await MethodAWithSameContext();
        for (int i = 101; i <= 200; i++)
        {
            result += (i * i);
        }

        Console.WriteLine("Thread ID After Calling MethodA : ".Pastel(ConsoleColor.Yellow) + Thread.CurrentThread.ManagedThreadId);
        return result;
    }
}