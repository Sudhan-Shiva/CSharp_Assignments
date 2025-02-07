using ValueReferenceTypes.Model;

public class Program
{
    static void Main()
    {
        int valueTypeInteger = 1;
        Product product = new Product("Apple", 1, 21, "Food");

        Console.WriteLine("Initial Value Type :"+valueTypeInteger);
        Console.WriteLine("Initial Reference Type :"+product.ProductName);

        void ValueChange(int testValue, Product testProduct)
        {
            testValue++;
            testProduct.ProductName = "Banana";
        }
        
        ValueChange(valueTypeInteger, product);

        Console.WriteLine("\nUpdated Value Type :" + valueTypeInteger);
        Console.WriteLine("Updated Reference Type :" + product.ProductName);

        Console.ReadKey();
    }  
}
