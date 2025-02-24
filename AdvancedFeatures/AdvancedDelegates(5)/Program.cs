using AdvancedDelegates;
using ConsoleTables;

/// <summary>
/// Entry point Class
/// </summary>
public class Program
{
    public delegate int SortDelegate(Product firstProduct, Product secondProduct);

    /// <summary>
    /// Main method which acts as the entry point
    /// </summary>
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

        Console.WriteLine("\n-----Sorting By Name------\n");
        SortAndDisplay(sortDelegateByName, productList);

        Console.WriteLine("\n-----Sorting By Category------\n");
        SortAndDisplay(sortDelegateByCategory, productList);

        Console.WriteLine("\n-----Sorting By Price------\n");
        SortAndDisplay(sortDelegateByPrice, productList);

        Console.ReadKey();
    }

    /// <summary>
    /// Method which takes two Product objects and return an integer based on the comparison of the product names.
    /// </summary>
    /// <param name="firstProduct">The first product</param>
    /// <param name="secondProduct">The second product</param>
    /// <returns>Integer which represents the comparison result of the two products</returns>
    static int SortByName(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Name.CompareTo(secondProduct.Name);
    }

    /// <summary>
    /// Method which takes two Product objects and return an integer based on the comparison of the product categories.
    /// </summary>
    /// <param name="firstProduct">The first product</param>
    /// <param name="secondProduct">The second product</param>
    /// <returns>Integer which represents the comparison result of the two products</returns>
    static int SortByCategory(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Category.CompareTo(secondProduct.Category);
    }

    /// <summary>
    /// Method which takes two Product objects and return an integer based on the comparison of the product prices.
    /// </summary>
    /// <param name="firstProduct">The first product</param>
    /// <param name="secondProduct">The second product</param>
    /// <returns>Integer which represents the comparison result of the two products</returns>
    static int SortByPrice(Product firstProduct, Product secondProduct)
    {
        return firstProduct.Price.CompareTo(secondProduct.Price);
    }

    /// <summary>
    /// Method to sort the list using the provided delegate and print the sorted list
    /// </summary>
    /// <param name="sortDelegate">Delegate based on which the list is sorted</param>
    /// <param name="productList">The list which must be sorted</param>
    static void SortAndDisplay(SortDelegate sortDelegate, List<Product> productList)
    {
        productList.Sort(sortDelegate.Invoke);

        ConsoleTable productTable = new ConsoleTable("Name", "Category", "Price");
        foreach (Product product in productList)
            productTable.AddRow(product.Name, product.Category, product.Price);

        productTable.Write();
    }
}
