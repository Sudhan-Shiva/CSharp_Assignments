using Task2.FileManager;

/// <summary>
/// Class which contains the main method
/// </summary>
public class Program
{
    /// <summary>
    /// The main method which acts as the EntryPoint of the project
    /// </summary>
    static void Main()
    {
        AsynchronousFileHandler asynchronousFileHandler = new AsynchronousFileHandler();
        int bufferLength = 1024 * 1024 * 10;

        string fileName = "testFile";
        asynchronousFileHandler.DeleteFileIfExists(fileName+".txt");
        asynchronousFileHandler.CreateLargeTextFile(fileName);

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