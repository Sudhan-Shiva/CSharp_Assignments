using System.Reflection;
using Pastel;

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
        //Path of the assembly
        string assemblyPath = "../../../../EventsAndDelegates(1).dll";
        var assembly = Assembly.LoadFrom(assemblyPath);
        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            Console.WriteLine("\nTYPE :\n".Pastel(ConsoleColor.Cyan));
            Console.WriteLine(type.FullName);

            Console.WriteLine("\nMETHODS :\n".Pastel(ConsoleColor.Magenta));
            var methods = type.GetMethods();
            foreach (var method in methods)
                Console.WriteLine(method.Name);

            Console.WriteLine("\nPROPERTIES :\n".Pastel(ConsoleColor.Magenta));
            var properties = type.GetProperties();
            foreach (var property in properties)
                Console.WriteLine(property.Name);

            Console.WriteLine("\nFIELDS :\n".Pastel(ConsoleColor.Magenta));
            var fields = type.GetFields();
            foreach (var field in fields)
                Console.WriteLine(field.Name);

            Console.WriteLine("\nEVENTS :\n".Pastel(ConsoleColor.Magenta));
            var events = type.GetEvents();
            foreach (var @event in events)
                Console.WriteLine(@event.Name);
        }

        Console.ReadKey();
    }
}
