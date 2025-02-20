public class Program
{   
    static void Main()
    {
        GlobalUnhandledExceptions globalUnhandledExceptions = new GlobalUnhandledExceptions();

        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

        globalUnhandledExceptions.executeTask4("invalidInput");

        Console.ReadKey();
    }

    static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception globalExceptionHandler = (Exception)args.ExceptionObject;
        Console.WriteLine("UnhandledExceptionHandler caught : " + globalExceptionHandler.Message);
        Console.WriteLine($"Runtime terminating: {args.IsTerminating}");
        Console.ReadKey();

    }
}
