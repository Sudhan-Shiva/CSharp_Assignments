using Task5.Model;

namespace Task5.Repository
{
    /// <summary>
    /// Represents the repository which contains the collection of suppliers
    /// </summary>
    public class SupplierRepository : IRepository<Supplier>
    {
        /// <summary>
        /// Represents the list of suppliers
        /// </summary>
        private List<Supplier> _supplierList = new List<Supplier>();

        /// <summary>
        /// To add a supplier into the list of suppliers
        /// </summary>
        /// <param name="supplier">The supplier which is to be added into the list</param>
        public void AddToRepository(Supplier supplier)
        {
            _supplierList.Add(supplier);
        }

        /// <summary>
        /// Returns the list of suppliers
        /// </summary>
        /// <returns>The list of suppliers</returns>
        public IEnumerable<Supplier> GetRepository() => _supplierList;
    }
}
