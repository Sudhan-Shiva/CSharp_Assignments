using InventoryManager.Model;
using InventoryManager.ValidInput;
using InventoryManager.AppFunctions;

namespace InventoryManager.MatchIndex
{
    public class IndexSearch
    {
        public bool IsIdOrNamePresent(Product product, string inputParameter, bool isProductName)
        {
            if (isProductName)
            { 
            return (product.ProductName == inputParameter);
            }
            else
            {
                int.TryParse(inputParameter, out int parsedId);
                return (product.ProductId == (parsedId));
            }
        }
    }
}





