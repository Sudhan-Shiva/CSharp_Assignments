using Task5.Model;
using Task5.Repository;
using ConsoleTables;
using Task5.Utility;

public class Program
{
    static void Main()
    {    
        IRepository<Product> productRepository = new ProductRepository();
        QueryBuilder<Product> queryBuilder = new QueryBuilder<Product>(productRepository.GetRepository());

        productRepository.AddToRepository(new Product("Phone", 7, 200, "Electronics"));
        productRepository.AddToRepository(new Product("Apple", 5, 20, "Food"));
        productRepository.AddToRepository(new Product("Tablet", 3, 400, "Electronics"));
        productRepository.AddToRepository(new Product("Laptop", 4, 450, "Electronics"));
        productRepository.AddToRepository(new Product("Ball", 2, 20, "Sports"));
        productRepository.AddToRepository(new Product("Play Station", 6, 1000, "Electronics"));
        productRepository.AddToRepository(new Product("Gaming Laptop", 1, 700, "Electronics"));
        productRepository.AddToRepository(new Product("Pizza", 8, 120, "Food"));

        var resultingList = queryBuilder.SortBy(p => p.ProductId)
                                       .Filter(p => p.ProductCategory.Equals("Electronics"))
                                       .Filter(p => p.ProductName.Contains('a'))
                                       .Execute();

        ConsoleTable resultantProducts = new ("Product Name", "Product ID", "Product Price", "Product Category");

        foreach (var filteredProduct in resultingList)
        {
            resultantProducts.AddRow(filteredProduct.ProductName, filteredProduct.ProductId, filteredProduct.ProductPrice, filteredProduct.ProductCategory);
        }

        resultantProducts.Write();

        IRepository<Supplier> supplierRepository = new SupplierRepository();
        QueryBuilder<Supplier> queryBuilderForSupplier = new QueryBuilder<Supplier>(supplierRepository.GetRepository());

        supplierRepository.AddToRepository(new Supplier("Supplier1", 10, 1));
        supplierRepository.AddToRepository(new Supplier("Supplier2", 11, 2));
        supplierRepository.AddToRepository(new Supplier("Supplier3", 12, 6));
        supplierRepository.AddToRepository(new Supplier("Supplier4", 13, 4));
        supplierRepository.AddToRepository(new Supplier("Supplier5", 14, 5));
        supplierRepository.AddToRepository(new Supplier("Supplier6", 15, 8));
        supplierRepository.AddToRepository(new Supplier("Supplier7", 16, 7));
        supplierRepository.AddToRepository(new Supplier("Supplier8", 17, 3));

        var resultList = queryBuilderForSupplier.SortBy(s => s.ProductId)
                                       .Filter(s => s.SupplierId > 13 )
                                       .Execute();

        ConsoleTable resultantSuppliers = new("Supplier Name", "Supplier ID", "Product ID");

        foreach (var filteredSupplier in resultList)
        {
            resultantSuppliers.AddRow(filteredSupplier.SupplierName, filteredSupplier.SupplierId, filteredSupplier.ProductId);
        }

        resultantSuppliers.Write();

        Console.ReadKey();
    }
}