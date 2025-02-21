using Task2.FileManager;

public class Program
{
    static void Main()
    {
        AsynchronousFileHandler asynchronousFileHandler = new AsynchronousFileHandler();
        int bufferLength = 1024 * 1024 * 10;

        string fileName = "testFile";
        asynchronousFileHandler.DeleteFileIfExists(fileName+".txt");

        asynchronousFileHandler.CreateTextFile(fileName);

        asynchronousFileHandler.ReadByFileStream(fileName, bufferLength);

        asynchronousFileHandler.ReadByBufferedStream(fileName, bufferLength);

        string processedFileName1 = "ProcessedFile1";
        asynchronousFileHandler.DeleteFileIfExists(processedFileName1 + ".txt");

        asynchronousFileHandler.WriteByMemoryStream(fileName, processedFileName1, bufferLength);

        string processedFileName2 = "ProcessedFile2";
        asynchronousFileHandler.DeleteFileIfExists(processedFileName2 + ".txt");

        asynchronousFileHandler.WriteByFileStream(fileName, processedFileName2, bufferLength);

        Console.WriteLine("\nPress any key to exit....");

        Console.ReadKey();
    }
}