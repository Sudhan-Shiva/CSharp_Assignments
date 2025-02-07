using GarbageCollection.Model;
using ConsoleTables;

public class Program
{
    static void Main()
    {
        int testValue = 10;

        void createArray()
        {
            Product[] testArray = new Product[100];
            ConsoleTable heapSizeTable = new ConsoleTable("Loop Count","Before Creation (bytes)", "After Creation (bytes)", "After Destruction (bytes)", "Memory Freed (Bytes)");

            for (int count = 0; count < 10; count++)
            {
                var heapSizeBeforeCreation = GC.GetTotalMemory(false);

                for (int index = 0; index < testArray.Length; index++)
                {
                    testArray[index] = new Product($"Name {testValue++}", testValue ++, testValue --, $"Category{testValue--}");                       
                }

                Thread.Sleep(2000);
                var heapSizeAfterCreation = GC.GetTotalMemory(false);

                Thread.Sleep(2000);
                GC.Collect();

                Thread.Sleep(2000);
                var heapSizeAfterDestruction = GC.GetTotalMemory(false);

                heapSizeTable.AddRow(count,  heapSizeBeforeCreation, heapSizeAfterCreation, heapSizeAfterDestruction, heapSizeAfterCreation - heapSizeAfterDestruction);
                Console.WriteLine("\n");
            }

            heapSizeTable.Write();
        }

        createArray(); 

        Console.ReadKey();
    }
}
