using Task5.Model;

namespace Task5.Repository
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private List<Supplier> _supplierList = new List<Supplier>();

        public void AddToRepository(Supplier supplier)
        {
            _supplierList.Add(supplier);
        }

        public IEnumerable<Supplier> GetRepository() => _supplierList;
    }
}
