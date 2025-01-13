using InventoryManager.MatchIndex;
using InventoryManager.ProductClass;

namespace InventoryManager.ValidInput
{
    public class UniqueInformation
    {
        //Create the required object references
        IndexSearch indexSearch = new IndexSearch();

        //Method to Prompt the user for a distinct input for product name and product  ID
        public string DistinctInputs(List<Product> productList, string inputParameter, bool isProductName)
        {
            //Loop till a unique input is received from the user
            while (indexSearch.ReturnIndex(productList, inputParameter, isProductName) != -1)
            {
                Console.WriteLine("The Product Field is Already Present !");
                Console.Write("Give a new Field : ");
                inputParameter = Console.ReadLine();
            }
            return inputParameter;
        }
    }
}


