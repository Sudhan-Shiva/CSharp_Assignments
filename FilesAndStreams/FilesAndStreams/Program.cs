using FilesAndStreams.FileManager;

public class Program
{
    static void Main()
    {
        DataHandler dataHandler = new DataHandler();
        do
        {
            dataHandler.WriteFile("TestFile.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
        } while (new FileInfo("TestFile.txt").Length < 1024 * 1024 * 1024);
    }
}