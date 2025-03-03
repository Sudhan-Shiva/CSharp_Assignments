using SerializationAPI;

public class Program
{
    static void Main()
    {
        Product product = new Product { Name = "Apple", Price = 12.345, Id = 1 };
        ReflectionApi.TestReflectionSerializer(product);
        Console.WriteLine();
        DynamicApi.TestDynamicApi(product);
        
        Console.WriteLine();
        object testInt = 7;
        ReflectionApi.TestReflectionSerializer(testInt);
        Console.WriteLine();
        DynamicApi.TestDynamicApi(testInt);
        
        Console.WriteLine();
        object testDouble = 2.25;
        ReflectionApi.TestReflectionSerializer(testDouble);
        Console.WriteLine();
        
        DynamicApi.TestDynamicApi(testDouble);
        Console.ReadKey();
    }
}
