using IDisposableDemo.FileHandler;

public class Program
{
    static void Main()
    {
        FileWriter fileWriter;

        Console.Write("Enter the file name : ");
        string testFileName = Console.ReadLine();
        using (fileWriter = new FileWriter($"{testFileName}.txt"))
        {
            Console.Write("Enter the text to be input : ");
            fileWriter.Write(Console.ReadLine());
        }

        using (FileReader fileReader = new FileReader($"{testFileName}.txt"))
        {
            Console.WriteLine("\nThe contents of the file :");
            Console.WriteLine(fileReader.Read());
        }

        Console.ReadKey();
    }
}
