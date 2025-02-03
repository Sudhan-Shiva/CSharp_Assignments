public class Program
{
    static void Main()
    {
        GlobalExceptionHandler globalExceptionHandler = new GlobalExceptionHandler();
        try
        {
            globalExceptionHandler.ExecuteTask5("Invalid");
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }

        Console.ReadKey();
    }
}
