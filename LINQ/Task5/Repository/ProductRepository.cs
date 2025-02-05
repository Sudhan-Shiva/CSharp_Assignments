using Task5.Model;

namespace Task5.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private List<Product> _productList = new List<Product>();

        public void AddToRepository(Product product)
        {
            _productList.Add(product);
        }

        public IEnumerable<Product> GetRepository() => _productList;
    }
}
