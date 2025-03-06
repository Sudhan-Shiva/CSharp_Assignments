using Task4.Model;
using ConsoleTables;
using Task4.Repository;

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

        productRepository.AddToRepository(new Product("Story", 1, 200, "Books"));
        productRepository.AddToRepository(new Product("Apple", 2, 20, "Food"));
        productRepository.AddToRepository(new Product("AutoBiography", 3, 400, "Books"));
        productRepository.AddToRepository(new Product("Comics", 4, 450, "Books"));
        productRepository.AddToRepository(new Product("Ball", 5, 20, "Sports"));
        productRepository.AddToRepository(new Product("Study", 6, 1000, "Books"));
        productRepository.AddToRepository(new Product("Fiction", 7, 700, "Books"));
        productRepository.AddToRepository(new Product("Pizza", 8, 120, "Food"));

        var booksCategoryProducts = productRepository.GetRepository().Where(product => product.ProductCategory.Equals("Books"))
            .OrderBy(books => books.ProductPrice);

        ConsoleTable filteredTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Category");
        foreach (var book in booksCategoryProducts)
        {
            filteredTable.AddRow(book.ProductName, book.ProductId, book.ProductPrice, book.ProductCategory);
        }
        filteredTable.Write();

        Console.ReadKey();
    }
}
