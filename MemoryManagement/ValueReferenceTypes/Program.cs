using ValueReferenceTypes.Model;

public class Program
{
    static void Main()
    {
        int valueTypeInteger = 1;
        Product product = new Product("Apple", 1, 21, "Food");

        // Print the inital reference type and value type variables
        Console.WriteLine("Initial Value Type :"+valueTypeInteger);
        Console.WriteLine("Initial Reference Type :"+product.ProductName);

        // Method that takes refrence type and value type as parameters and modifies them
        void ValueChange(int testValue, Product testProduct)
        {
            testValue++;
            testProduct.ProductName = "Banana";
        }
        
        ValueChange(valueTypeInteger, product);

        // Print the updated reference type and value type variables
        Console.WriteLine("\nUpdated Value Type :" + valueTypeInteger);
        Console.WriteLine("Updated Reference Type :" + product.ProductName);

        Console.ReadKey();
    }  
}
