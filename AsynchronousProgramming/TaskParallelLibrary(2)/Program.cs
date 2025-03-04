public class Program
{
    static void Main()
    {
        int[] intArray = new int[1000];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i;
        }

        Console.WriteLine("Squared integers : ");
        Parallel.ForEach(intArray, integer =>
        {
            Console.Write(integer * integer + ", ");
        });

        Console.ReadKey();
    }
}
