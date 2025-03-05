public class Program
{
    static void Main()
    {
        TestAsynchronousExceptions();
        Console.ReadKey();
    }

    async static void ThrowAsyncVoidException()
    {
        //throw new Exception("This is an exception thrown from an async void method !!!");
        //The async void methods throws exception on the synchronisation context and can only be handled by the AppDomain.Unhandled exception.
    }

    async static Task ThrowAsyncTaskException()
    {
        throw new Exception("This is an exception thrown from an async task method !!!");
        //The async task method throws exception along with the task returned and therefore the exception can be caught using a try-catch block.
    }

    async static void TestAsynchronousExceptions()
    {
        try
        {
            ThrowAsyncVoidException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            await ThrowAsyncTaskException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
