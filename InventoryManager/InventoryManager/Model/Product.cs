namespace InventoryManager.Model
{
    /// <summary>
    /// To Store the Product Information
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The ID of the Product
        /// </summary>
        public int ProductId;

        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName;

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal ProductPrice;

        /// <summary>
        /// The quantity of the product
        /// </summary>
        public int ProductQuantity;

        /// <summary>
        /// Represents the product with the required details
        /// </summary>
        /// <param name="productId">The Id of the product</param>
        /// <param name="productName">The Name of the product</param>
        /// <param name="productPrice">The Price of the product</param>
        /// <param name="productQuantity">The Quantity of the product</param>
        public Product(int productId, string productName, decimal productPrice, int productQuantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}
