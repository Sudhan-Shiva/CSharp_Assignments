using IDisposableDemo.FileHandler;

public class Program
{
    static void Main()
    {
        FileWriter fileWriter;
        FileReader fileReader;

        Console.Write("Enter the file name : ");
        string testFileName = Console.ReadLine();

        //Create using block for implementing dispose method
        using (fileWriter = new FileWriter($"{testFileName}.txt"))
        {
            Console.Write("Enter the text to be input : ");

            //Write to the file
            fileWriter.Write(Console.ReadLine());
        }

        //Create using block for implementing dispose method
        using (fileReader = new FileReader($"{testFileName}.txt"))
        {
            Console.WriteLine("\nThe contents of the file :");

            //Read the file contents
            Console.WriteLine(fileReader.Read());
        }

        Console.ReadKey();
    }
}
