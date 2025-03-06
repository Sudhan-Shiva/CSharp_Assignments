using Task2.Model;
using ConsoleTables;
using Task2.Repository;

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

        var groupProductsByCategory = productRepository.GetRepository().GroupBy(product => product.ProductCategory);

        var productCountInEachCategory = groupProductsByCategory.Select(product => 
            (product.First().ProductCategory,
            product.Count()));

        ConsoleTable categoryDetails = new ConsoleTable("Product Category", "Product Count");
        foreach (var categoryJoins in productCountInEachCategory)
        {
            categoryDetails.AddRow(categoryJoins.Item1,categoryJoins.Item2 );
        }

        Console.WriteLine("\nThe number of products in each category :");
        categoryDetails.Write();

        var expensiveProductInEachCategory = groupProductsByCategory
            .Select(product => 
            (product.First().ProductCategory, 
            product.MaxBy(product => product.ProductPrice).ProductName, 
            product.MaxBy(product => product.ProductPrice).ProductPrice));

        ConsoleTable expensiveProductDetails = new ConsoleTable("Product Category", "Most Expensive Product Name", "Most Expensive Product Price");
        foreach(var expensiveProduct in expensiveProductInEachCategory)
        {
            expensiveProductDetails.AddRow(expensiveProduct.ProductCategory, expensiveProduct.ProductName, expensiveProduct.ProductPrice);
        }

        Console.WriteLine("\nThe most expensive product details present in each category :");
        expensiveProductDetails.Write();

        SupplierRepository supplierRepository = new SupplierRepository();

        supplierRepository.AddToRepository(new Supplier ("Supplier1", 10, 1) );
        supplierRepository.AddToRepository(new Supplier ("Supplier2", 11, 2) );
        supplierRepository.AddToRepository(new Supplier ("Supplier3", 12, 6) );
        supplierRepository.AddToRepository(new Supplier ("Supplier4", 13, 4) );
        supplierRepository.AddToRepository(new Supplier ("Supplier5", 14, 5) );
        supplierRepository.AddToRepository(new Supplier ("Supplier6", 15, 8) );
        supplierRepository.AddToRepository(new Supplier ("Supplier7", 15, 7) );
        supplierRepository.AddToRepository(new Supplier ("Supplier8", 16, 3) );

        var productAndSupplierJoin = productRepository.GetRepository()
            .Join(supplierRepository.GetRepository(), 
            product => product.ProductId, 
            supplier => supplier.ProductId,
            (product , supplier) => new { supplierName = supplier.SupplierName ,productName = product.ProductName, commonId = product.ProductId });

        Console.WriteLine("\nThe correlation between supplier and products : ");
        foreach (var product in productAndSupplierJoin)
        {
            Console.WriteLine("\nProduct Name : "+product.productName);
            Console.WriteLine("Product ID : "+product.commonId);
            Console.WriteLine("Supplier : "+ product.supplierName);
            Console.WriteLine("\n-----------------------------------");
        }
        
        Console.ReadKey();
    }
}
