/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static void Main()
    {
        DeadlockMethod();

        Console.ReadKey();
    }

    /// <summary>
    /// Method to simulate deadlock
    /// </summary>
    /// <returns></returns>
    static async Task DeadlockMethod()
    {
        var asyncResult = SomeAsyncOperation().Result;
        //Result blocks main thread from execution till the asyncResult is returned from the SomeAsyncOperation().

        Console.WriteLine(asyncResult);
    }

    /// <summary>
    /// Method to return a string after certain delay
    /// </summary>
    /// <returns>An output string</returns>
    static async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000).ConfigureAwait(false);
        //Here, await continues the execution asynchronously as the delay occurs.
        //The execution is attempted to continue on a different context since the ConfigureAwait(false) is used.
        //This resolves any deadlock situation since the program executes on a different context.

        return "Hello, World!";
    }
}
