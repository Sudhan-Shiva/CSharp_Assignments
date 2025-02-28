using System.Reflection;

public class Program
{
    public static void Main()
    {
        string assemblyPath = "../../../../MethodHelper.dll";
        var assembly = Assembly.LoadFrom(assemblyPath);
        Console.WriteLine($"Assembly is successfully loaded !!!\n");

        DynamicMethodInvoker.MethodInvoker methodInvoker = new DynamicMethodInvoker.MethodInvoker();

        string? typeName = "Program";
        var types = assembly.GetTypes();
        var requiredType = types.FirstOrDefault(i => i.FullName.Equals(typeName));

        string? methodName = "TestMethod";
        methodInvoker.InvokeMethod(Activator.CreateInstance(requiredType), methodName);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}