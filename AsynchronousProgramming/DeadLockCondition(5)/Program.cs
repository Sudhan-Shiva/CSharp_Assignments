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
        //Result blocks main thread from execution till the result is returned frm the SomeAsyncOperation().

        Console.WriteLine(asyncResult);
    }

    static async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(2000);
        //Here, await continues the execution on the main thread asynchronously as the delay occurs.
        //The execution is attemped to continue on the main thread but the main thread is blocked by the
        return "Hello, World!";
    }
}