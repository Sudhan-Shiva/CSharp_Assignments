namespace AdvancedDelegates
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Product(string Name, string Category, double Price)
        {
            this.Name = Name;
            this.Category = Category;
            this.Price = Price;
        }
    }
}
