using Pastel;
using Task1.FileManager;

public class Program
{
    static void Main()
    {
        Console.WriteLine("-----WELCOME-----".Pastel(ConsoleColor.Magenta));
        Console.Write("\nProvide the name of the file to be created : ".Pastel(ConsoleColor.Yellow));
        string? fileName = Console.ReadLine();
        SynchronousFileHandler synchronousFileHandler = new SynchronousFileHandler();

        synchronousFileHandler.CreateLargeTextFile(fileName);

        synchronousFileHandler.ReadByBufferedStream(fileName);

        synchronousFileHandler.ReadByFileStream(fileName);
            
        Console.Write("\nProvide the name of the file to be created after processing : ".Pastel(ConsoleColor.Yellow));
        string? processedFileName = Console.ReadLine();

        synchronousFileHandler.WriteByMemoryStream(fileName, processedFileName);

        synchronousFileHandler.CheckFileContent(fileName, processedFileName);

        Console.WriteLine("\nPress any key to exit....");
        Console.ReadKey();
    }
}