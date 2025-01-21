using InventoryManager.Model;
using ConsoleTables;
using InventoryManager.AppFunctions;

namespace InventoryManager.PrintInformation
{
    public class ProductInformation
    {
        //Method to print all the information of the required product
        public void PrintTable(ConsoleTable productTable)
        {
            productTable.Write();
        }
    }
}
