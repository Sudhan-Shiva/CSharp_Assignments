using Task1.Model;
using ConsoleTables;
using Task1.Repository;

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
        ProductRepository productRepository = new ProductRepository();

        productRepository.AddToRepository(new Product("Phone", 1, 200, "Electronics"));
        productRepository.AddToRepository(new Product("Apple", 2, 20, "Food"));
        productRepository.AddToRepository(new Product("Tablet", 3, 400, "Electronics"));
        productRepository.AddToRepository(new Product("Laptop", 4, 450, "Electronics"));
        productRepository.AddToRepository(new Product("Ball", 5, 20, "Sports"));
        productRepository.AddToRepository(new Product("Play Station", 6, 1000, "Electronics"));
        productRepository.AddToRepository(new Product("Gaming Laptop", 7, 700, "Electronics"));
        productRepository.AddToRepository(new Product("Pizza", 8, 120, "Food"));

        var products = productRepository.GetRepository().Where((product) => product.ProductPrice < 500 && product.ProductCategory.Equals("Electronics") );
        
        var productsNameAndPrice = products.Select(product => new { product.ProductName, product.ProductPrice })
            .OrderByDescending(product => product.ProductPrice);
        
        ConsoleTable filteredTable = new ConsoleTable("Product Name", "Product Price");
        foreach (var product in productsNameAndPrice)
        {
            filteredTable.AddRow(product.ProductName, product.ProductPrice);         
        }

        Console.WriteLine("The products under category 'Electronics' in descending order of Product Price : ");
        filteredTable.Write();

        var avgPrice = productsNameAndPrice.Average(product => product.ProductPrice);
        Console.WriteLine($"\nThe average of the product prices is equal to {avgPrice}.");

        Console.ReadKey();
    }
}
