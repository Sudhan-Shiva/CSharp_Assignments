using System;
using System.Diagnostics;
using System.Text;
using Task1.FileManager;

public class Program
{
    static void Main()
    {
        Console.Write("Provide the name of the file to be created : ");
        string? fileName = Console.ReadLine();

        CreateLargeTextFile(fileName);
        
        ReadByFileStream(fileName);
        
        ReadByBufferedStream(fileName);
            
        Console.Write("\nProvide the name of the file to be created after processing : ");
        string? processedFileName = Console.ReadLine();

        WriteByMemoryStream(fileName, processedFileName);

        CheckFileContent(fileName, processedFileName);

        Console.WriteLine("\nPress any key to exit....");
        Console.ReadKey();
    }

    private static void CheckFileContent(string fileName, string processedFileName)
    {
        using (StreamReader testReader = new StreamReader($"{fileName}.txt"))
        {
            Console.WriteLine("\nThe previous first line in the file : " + testReader.ReadLine());
        }

        using (StreamReader testReader = new StreamReader($"{processedFileName}.txt"))
        {
            Console.WriteLine("\nThe first line in the file after processing : " + testReader.ReadLine());
        }
    }

    private static void WriteByMemoryStream(string fileName, string processedFileName)
    {
        Console.WriteLine("\n-------File is being processed-------");

        using (FileStream fileReaderStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileWriterStream = new FileStream($"{processedFileName}.txt", FileMode.Create, FileAccess.Write))
                {
                    int bufferLength = 1024 * 1024 * 10;
                    byte[] buffer = new byte[bufferLength];

                    while (new FileInfo(fileName + ".txt").Length > new FileInfo(processedFileName + ".txt").Length)
                    {
                        fileReaderStream.Read(buffer, 0, bufferLength);
                        string upperCaseString = Encoding.UTF8.GetString(buffer).ToUpper();
                        memoryStream.Write(Encoding.UTF8.GetBytes(upperCaseString));
                        memoryStream.WriteTo(fileWriterStream);
                    }
                }
            }
        }
    }

    private static void ReadByBufferedStream(string fileName)
    {
        Stopwatch stopWatch = new Stopwatch();
        int bufferLength = 1024 * 1024 * 20;
        byte[] buffer = new byte[bufferLength];
        int bytesRead = 0;
        int currentBytesRead = 0;

        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferLength))
            {
                Console.WriteLine("\n-----Reading By Buffered Stream-----");
                stopWatch.Restart();

                while ((currentBytesRead = bufferedStream.Read(buffer, 0, bufferLength)) > 0)
                {
                    bytesRead += currentBytesRead;
                }

                stopWatch.Stop();

                Console.WriteLine($"\nThe size of the file read : {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
                Console.WriteLine($"The time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using BufferedStream is : {stopWatch.ElapsedMilliseconds} Milliseconds");
            }
        }
    }

    private static void ReadByFileStream(string fileName)
    {
        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            Stopwatch stopWatch = new Stopwatch();
            int bufferLength = 1024 * 1024 * 20;
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;
            int currentBytesRead = 0;

            Console.WriteLine("\n-----Reading By File Stream-----");
            stopWatch.Start();

            while ((currentBytesRead = fileStream.Read(buffer, 0, bufferLength)) > 0)
            {
                bytesRead += currentBytesRead;
            }
            stopWatch.Stop();

            Console.WriteLine($"\nThe size of the file read : {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
            Console.WriteLine($"The time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using FileStream is : {stopWatch.ElapsedMilliseconds} Milliseconds");
        }
    }

    private static void CreateLargeTextFile(string fileName)
    {
        DataHandler dataHandler = new DataHandler();

        Console.WriteLine("\n-------File is being created-------");

        do
        {
            dataHandler.WriteFile($"{fileName}.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
        } while (new FileInfo($"{fileName}.txt").Length < 1024.0 * 1024 * 1024);

        Console.WriteLine($"\nFile of size {(new FileInfo($"{fileName}.txt").Length / (1024.0 * 1024 * 1024))} Gigabytes is successfully created.");
    }
}