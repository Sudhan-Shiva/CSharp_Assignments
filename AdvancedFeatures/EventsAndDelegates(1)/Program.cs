using EventsAndDelegates;

/// <summary>
/// Entry point Class
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the entry point
    /// </summary>
    static void Main()
    {
        Notifier notifier = new Notifier();

        notifier.OnAction += MessagePrinter;
        notifier.TriggerEvent("\nEVENT SUCCESSFULLY TRIGGERED !!!!");
        notifier.OnAction -= MessagePrinter;

        notifier.OnAction += MessagePrinter;
        notifier.TriggerEvent("\nPress any key to exit....");
        notifier.OnAction -= MessagePrinter;

        Console.ReadKey();
    }

    /// <summary>
    /// To print a message to the console
    /// </summary>
    /// <param name="message">The message to be printed to the console</param>
    static void MessagePrinter(string message)
    {
        Console.WriteLine(message);
    }
}
