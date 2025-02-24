/// <summary>
/// Product Class
/// </summary>
public class Product
{
    /// <summary>
    /// Name of the product
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ID of the product
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Price of the product
    /// </summary>
    public double Price { get; set; }

    public Product(string Name, int Id, double Price) 
    {
        this.Name = Name;
        this.Id = Id;
        this.Price = Price;
    }
}
