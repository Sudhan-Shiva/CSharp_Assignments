using SerializationAPI;

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
        //User defined type
        Product product = new Product { Name = "Apple", Price = 12.345, Id = 1 };
        ReflectionApi.TestReflectionSerializer(product);
        DynamicApi.TestDynamicApi(product);
        
        //Primitive types
        int testInt = 7;
        ReflectionApi.TestReflectionSerializer(testInt);
        DynamicApi.TestDynamicApi(testInt);
        
        double testDouble = 2.25;
        ReflectionApi.TestReflectionSerializer(testDouble);
        DynamicApi.TestDynamicApi(testDouble);

        Console.ReadKey();
    }
}
