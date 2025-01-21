namespace InventoryManager.Model
{
    //Define Class to Store the Product Information
    public class Product
    {
        public int ProductId;
        public string ProductName;
        public decimal ProductPrice;
        public int ProductQuantity;

        //Constructor Block
        public Product(int productId, string productName, decimal productPrice, int productQuantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}



