public class Program
{
    static void Main()
    {
        DeadlockMethod();

        Console.ReadKey();
    }

    static async Task DeadlockMethod()
    {
        var asyncResult = SomeAsyncOperation().Result;
        //Result blocks main thread from execution till the asyncResult is returned from the SomeAsyncOperation().

        Console.WriteLine(asyncResult);
    }

    static async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000).ConfigureAwait(false);
        //Here, await continues the execution asynchronously as the delay occurs.
        //The execution is attempted to continue on a different context since the ConfigureAwait(false) is used.
        //This resolves any deadlock situation since the program executes on a different context.

        return "Hello, World!";
    }
}