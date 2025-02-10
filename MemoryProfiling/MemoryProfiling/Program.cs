using ConsoleTables;

/// <summary>
/// Class to define methods to analyze memory usage
/// </summary>
public class MemoryEater
{
    List<int[]> memAlloc = new List<int[]>();

    /// <summary>
    /// Method to allocate heap memory
    /// </summary>
    public void Allocate()
    {
        ConsoleTable memoryTable = new ConsoleTable("Loop Count", "Occupied Heap Memory (Bytes)");
        int loopCount = 0;

        //Loop which continuously allocates memory by adding new objects
        while (true)
        {
            memAlloc.Add(new int[1000]);
            // Assume memAlloc variable is used only within this loop.
            Thread.Sleep(1000);

            memoryTable.AddRow(++loopCount, GC.GetTotalMemory(false));
            memoryTable.Write();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MemoryEater me = new MemoryEater();
        me.Allocate();
    }
}
