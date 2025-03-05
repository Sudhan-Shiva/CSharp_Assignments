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
        TestAsynchronousExceptions();
        Console.ReadKey();
    }

    /// <summary>
    /// To simulate an async void method that throws an exception. 
    /// </summary>
    async static void ThrowAsyncVoidException()
    {
        //throw new Exception("This is an exception thrown from an async void method !!!");
        //The async void methods throws exception on the synchronisation context and can only be handled by the AppDomain.Unhandled exception.
    }

    /// <summary>
    /// To simulate an async task method that throws an exception. 
    /// </summary>
    /// <returns>Throws an exception</returns>
    /// <exception cref="Exception">Throw a simple exception for testing</exception>
    async static Task ThrowAsyncTaskException()
    {
        throw new Exception("This is an exception thrown from an async task method !!!");
        //The async task method throws exception along with the task returned and therefore the exception can be caught using a try-catch block.
    }

    /// <summary>
    /// To implement try-catch blocks for testing async void and async task exceptions.
    /// </summary>
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
