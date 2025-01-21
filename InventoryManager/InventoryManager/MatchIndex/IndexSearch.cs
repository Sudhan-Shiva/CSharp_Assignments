using InventoryManager.Model;
using InventoryManager.ValidInput;

namespace InventoryManager.MatchIndex
{
    public class IndexSearch
    {
        //Create the required object references 
        DataValidation dataValidation = new DataValidation();
        //Method to return the index of the matching product in the list
        public int ReturnIndex(List<Product> productList, string inputParameter, bool isProductName)
        {
            foreach (Product product in productList)
            {
                if (IsIdOrNamePresent(product, inputParameter, isProductName))
                {
                    //Return the INdex of the matched Product
                    return productList.IndexOf(product);
                }
            }
            //If no matching product is found, -1 is returned.
            return -1;
        }

        //Method to check for the matched product based on name or ID
        public bool IsIdOrNamePresent(Product product, string inputParameter, bool isProductName)
        {
            return isProductName ? (product.ProductName == inputParameter) : (product.ProductId == dataValidation.IsDataValid(inputParameter));
        }
    }
}





