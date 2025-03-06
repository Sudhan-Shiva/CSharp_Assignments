using Task4.Model;

namespace Task4.Repository
{
    /// <summary>
    /// Represents the repository which contains the collection of products
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Represents the list of products
        /// </summary>
        private List<Product> _productList = new List<Product>();

        /// <summary>
        /// To add a product into the list of products
        /// </summary>
        /// <param name="product">The product which is to be added into the list</param>
        public void AddToRepository(Product product)
        {
            _productList.Add(product);
        }

        /// <summary>
        /// Returns the list of products
        /// </summary>
        /// <returns>The list of products</returns>
        public IEnumerable<Product> GetRepository() => _productList;
    }
}
