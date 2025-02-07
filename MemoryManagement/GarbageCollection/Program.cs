using GarbageCollection.Model;
using ConsoleTables;

public class Program
{
    /// <summary>
    /// Method to create a large array
    /// </summary>
    /// <returns>The Console Table containing of the memory changes in the heap size</returns>
    public static ConsoleTable createArray(int testValue)
    {
        //Create a large array of products
        Product[] testArray = new Product[100];
        ConsoleTable heapSizeTable = new ConsoleTable("Loop Count", "Before Creation (bytes)", "After Creation (bytes)", "After Destruction (bytes)", "Memory Freed (Bytes)");

        //Loop to catch the heap size multiple times before creating and destroying the array
        for (int count = 0; count < 10; count++)
        {
            //Calculate the heap memory before the creation of the objects
            var heapSizeBeforeCreation = GC.GetTotalMemory(false);

            //Loop to assign products to the array
            for (int index = 0; index < testArray.Length; index++)
            {
                testArray[index] = new Product($"Name {testValue++}", testValue++, testValue--, $"Category{testValue--}");
            }

            //Introduce delay for a clear view of the changes in process memory graph
            Thread.Sleep(2000);

            //Calculate the heap memory after the creation of the objects
            var heapSizeAfterCreation = GC.GetTotalMemory(false);

            //Introduce delay for a clear view of the changes in process memory graph
            Thread.Sleep(2000);

            //Call the GC.cCollect method for garbage collection of unused variables
            GC.Collect();

            //Introduce delay for a clear view of the changes in process memory graph
            Thread.Sleep(2000);

            // Calculate the heap memory after the destruction of the objects
            var heapSizeAfterDestruction = GC.GetTotalMemory(false);

            heapSizeTable.AddRow(count, heapSizeBeforeCreation, heapSizeAfterCreation, heapSizeAfterDestruction, heapSizeAfterCreation - heapSizeAfterDestruction);
            Console.WriteLine("\n");
        }

        return heapSizeTable;
    }

    static void Main()
    {
        int testValue = 10;

        createArray(testValue).Write(); 

        Console.ReadKey();
    }
}
