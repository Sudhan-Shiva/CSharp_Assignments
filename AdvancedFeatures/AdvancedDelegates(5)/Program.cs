using AdvancedDelegates;
using ConsoleTables;

public class Program
{
    public delegate int SortDelegate(Product firstProduct, Product secondProduct) ;
    static void Main()
    {
        List<Product> productList = new List<Product>();
        productList.Add(new Product("Apple", "Food", 100.50));
        productList.Add(new Product("Harry Potter", "Book", 500));
        productList.Add(new Product("Tea", "Beverage", 15.0));
        productList.Add(new Product("Pie", "Food", 175.20));
        productList.Add(new Product("Origin", "Book", 370));

        SortDelegate sortDelegateByName = SortByName;
        SortDelegate sortDelegateByCategory = SortByCategory;
        SortDelegate sortDelegateByPrice = SortByPrice;

        Console.WriteLine("-----Sorting By Name------\n");
        SortAndDisplay(sortDelegateByName, productList);

        Console.WriteLine("-----Sorting By Category------\n");
        SortAndDisplay(sortDelegateByCategory, productList);

        Console.WriteLine("-----Sorting By Price------\n");
        SortAndDisplay(sortDelegateByPrice, productList);

        Console.ReadKey();
    }

    static int SortByName(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Name.CompareTo(secondProduct.Name);
    }
    static int SortByCategory(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Category.CompareTo(secondProduct.Category);
    }

    static int SortByPrice(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Price.CompareTo(secondProduct.Price);
    }

    static void SortAndDisplay(SortDelegate sortDelegate, List<Product> productList)
    {
        productList.Sort(sortDelegate.Invoke);

        ConsoleTable productTable = new ConsoleTable("Name", "Category", "Price");
        foreach(Product product in productList)
            productTable.AddRow(product.Name, product.Category, product.Price);

        productTable.Write();
    }
}
