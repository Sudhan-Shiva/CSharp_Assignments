/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static void Main()
    {
        int[] intArray = new int[1000];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i;
        }

        Console.WriteLine("Squared integers : ");

        //Parallel Library creates multiple threads and executes loop iterations in separate threads asynchronously.
        Parallel.ForEach(intArray, integer =>
        {
            Console.Write(integer * integer + ", ");
        });

        Console.ReadKey();
    }
}
