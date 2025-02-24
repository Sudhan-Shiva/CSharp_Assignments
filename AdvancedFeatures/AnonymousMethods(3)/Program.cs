/// <summary>
/// Entry point Class
/// </summary>
public class Program
{
    public delegate void TestDelegate(int[] intArray);

    /// <summary>
    /// Main method which acts as the entry point
    /// </summary>
    static void Main()
    {
        int[] testArray = [3, 1, 7, 2, 3, 5, 4];
        Console.Write("The Original Array : ");
        foreach (int i in testArray) { Console.Write(i + ", "); }
        Console.WriteLine();

        TestDelegate anonymousMethod = delegate (int[] testArray)
        {
            Array.Sort(testArray);
        };

        anonymousMethod(testArray);

        Console.Write("The Sorted Array : ");
        foreach (int i in testArray) { Console.Write(i + ", "); }

        Console.ReadKey();
    }
}
