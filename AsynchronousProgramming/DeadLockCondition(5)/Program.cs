public class Program
{
    static void Main()
    {
        DeadlockMethod();
        Console.ReadKey();
    }

    static async Task DeadlockMethod()
    {
        var asyncResult = await SomeAsyncOperation();
        //Here, await continues the execution asynchronously by returning the main thread to the thread pool.

        Console.WriteLine(asyncResult);
    }

    static async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(2000);
        //Here, await continues the execution on the main thread asynchronously as the delay occurs.
        //The execution is attempted to continue on the main thread.
        //This doesn't cause deadlock since the main thread is available for execution since await is an non-blocking operation.

        return "Hello, World!";
    }
}