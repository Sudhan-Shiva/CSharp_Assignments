namespace InventoryManager.Model
{
    public enum ApplicationOptions
    {
        /// <summary>
        /// To view all the Products
        /// </summary>
        ViewProducts,

        /// <summary>
        /// To add a new Product
        /// </summary>
        AddProduct,

        /// <summary>
        /// To delete an older Product
        /// </summary>
        DeleteProduct,

        /// <summary>
        /// To edit a Product
        /// </summary>
        EditProduct,

        /// <summary>
        /// To search for a specific Product
        /// </summary>
        SearchProduct,

        /// <summary>
        /// To sort the product list
        /// </summary>
        SortProducts,

        /// <summary>
        /// To exit the application
        /// </summary>
        Exit
    }

    /// <summary>
    /// To define the edit choices in the Product
    /// </summary>
    public enum UserEditChoice
    {
        /// <summary>
        /// Edit the Product Name
        /// </summary>
        EditProductName,

        /// <summary>
        /// Edit the Product ID
        /// </summary>
        EditProductId,

        /// <summary>
        /// Edit the Product Price
        /// </summary>
        EditProductPrice,

        /// <summary>
        /// Edit the Product Quantity
        /// </summary>
        EditProductQuantity
    }

    /// <summary>
    /// To define the sort by methods in the product list
    /// </summary>
    public enum NameOrIdChoice
    {
        /// <summary>
        /// Sort the product list by name
        /// </summary>
        ByName,

        /// <summary>
        /// Sort the product list by Id
        /// </summary>
        ById
    }
}
