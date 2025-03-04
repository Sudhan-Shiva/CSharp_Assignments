using System.Reflection;
using DynamicObjectInspector;
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
        string assemblyPath = "../../../../ProductClass.dll";
        var assembly = Assembly.LoadFrom(assemblyPath);
        var types = assembly.GetTypes();

        ObjectInspector objectInspector = new ObjectInspector();

        foreach (Type type in types)
        {
            objectInspector.InspectProperty(Activator.CreateInstance(type));
        }

        Console.WriteLine("\nAfter Modification......".Pastel(ConsoleColor.Cyan));

        foreach (Type type in types)
        {
            object obj = Activator.CreateInstance(type);
            objectInspector.SetPropertyValue(obj, "Name", "ModifiedName");
            objectInspector.SetPropertyValue(obj, "Price", 100.77);
            objectInspector.SetPropertyValue(obj, "Id", 10);
            objectInspector.InspectProperty(obj);
        }

        Console.ReadKey();
    }
}