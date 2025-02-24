public class Program
{
    static void Main()
    {
        List<int> testList = new List<int> { 1,2,3,4,5,6,7,8,9,0 };
        Console.Write("The Original List : ");
        foreach (int i in testList) { Console.Write(i + ", "); }
        Console.WriteLine();

        var oddNumbersList = testList.Where(i => i % 2 != 0);
        Console.Write("The Odd Number List : ");
        foreach (int i in oddNumbersList) { Console.Write(i+", "); }
        Console.WriteLine();

        var squaredOddNumbersList = oddNumbersList.Select(i => i*i);
        Console.Write("The Squared Odd Number List : ");
        foreach(int i in squaredOddNumbersList) { Console.Write(i+", "); }

        Console.ReadKey();
    }
}