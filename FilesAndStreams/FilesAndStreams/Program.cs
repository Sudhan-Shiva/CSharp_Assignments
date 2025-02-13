using System.Diagnostics;
using System.IO;
using FilesAndStreams.FileManager;

public class Program
{
    static void Main()
    {
        //DataHandler dataHandler = new DataHandler();
        //do
        //{
        //    dataHandler.WriteFile("TestFile.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
        //} while (new FileInfo("TestFile.txt").Length < 1024 * 1024 * 1024);

        char[] buffer = null;
        int bufferLength = 1024*1024;
        int bytesRead = 0;

        Stopwatch stopWatch = new Stopwatch();

        using (FileStream fileStream = new FileStream("TestFile.txt", FileMode.Open, FileAccess.Read))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                stopWatch.Start();

                while (fileStream.Position != fileStream.Length)
                {
                    buffer = new char[bufferLength];
                    bytesRead += streamReader.Read(buffer, 0, bufferLength);
                }

                Console.WriteLine($"The size of the file read : {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
                stopWatch.Stop();

                Console.WriteLine($"The time elapsed to read the file in chunks of {bufferLength/(1024.0*1024)} MegaBytes using FileStream is : {stopWatch.Elapsed} seconds");
            }
        }

        using (FileStream fileStream = new FileStream("TestFile.txt", FileMode.Open, FileAccess.Read))
        {

            using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferLength))
            {
                using (StreamReader streamReader = new StreamReader(bufferedStream))
                {
                    bytesRead = 0;
                    stopWatch.Restart();

                    while (bufferedStream.Position != fileStream.Length)
                    {
                        buffer = new char[bufferLength];
                        bytesRead += streamReader.Read(buffer, 0, bufferLength);
                    }

                    Console.WriteLine($"\nThe size of the file read : {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
                    stopWatch.Stop();

                    Console.WriteLine($"The time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using BufferedStream is : {stopWatch.Elapsed} seconds");
                }
            }
        }

        Console.ReadKey();
    }
}