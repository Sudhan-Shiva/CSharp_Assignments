namespace Task2.Model
{
    /// <summary>
    /// Represents the supplier
    /// </summary>
    public class Supplier
    {    
        /// <summary>
        /// The name of the supplier
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// The ID of the supplier
        /// </summary>
        public int SupplierId {  get; set; }

        /// <summary>
        /// The ID of the product supplied by the supplier
        /// </summary>
        public int ProductId {  get; set; }

        public Supplier( string supplierName, int supplierId, int productId)
        {         
            this.SupplierName = supplierName;
            this.SupplierId = supplierId;
            this.ProductId = productId;
        }   
    }
}
