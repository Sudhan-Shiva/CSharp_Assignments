using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Task2.FileManager;

public class Program
{
    static async Task Main()
    {
        int bufferLength = 1024 * 1024 * 10;

        string fileName = "testFile.txt";
        DeleteFileIfExists(fileName);

        CreateTextFile(fileName);

        ReadByFileStream(fileName, bufferLength);

        ReadByBufferedStream(fileName, bufferLength);

        string processedFileName1 = "ProcessedFile1.txt";
        DeleteFileIfExists(processedFileName1);

        WriteByMemoryStream(fileName, processedFileName1, bufferLength);

        string processedFileName2 = "ProcessedFile2.txt";
        DeleteFileIfExists(processedFileName2);

        WriteByFileStream(fileName, processedFileName2, bufferLength);

        Console.WriteLine("\nPress any key to exit....");

        Console.ReadKey();
    }

    private static void DeleteFileIfExists(string FileName)
    {
        if (File.Exists(FileName))
            File.Delete(FileName);
    }

    private static void CheckFileContents(string fileName, string processedFileName)
    {
        using (StreamReader testReader = new StreamReader($"{fileName}.txt"))
        {
            Console.WriteLine("\nThe previous first line in the file is : " + testReader.ReadLine());
        }

        using (StreamReader testReader = new StreamReader($"{processedFileName}.txt"))
        {
            Console.WriteLine("The current first line after the file is processed : " + testReader.ReadLine());
        }
    }

    static void CreateTextFile(string fileName)
    {
        DataHandler dataHandler = new DataHandler();

        Console.WriteLine("\n-------File is being created-------");
        do
        {
            dataHandler.WriteFile($"{fileName}.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
        } while (new FileInfo($"{fileName}.txt").Length < 1024.0 * 1024 * 1024);

        Console.WriteLine($"\nFile of size {new FileInfo($"{fileName}.txt").Length / 1024.0 * 1024 * 1024} Bytes is successfully created.");
    }

    static async void ReadByFileStream(string fileName, int bufferLength)
    {
        byte[] buffer = new byte[bufferLength];
        int bytesRead = 0;
        Stopwatch stopWatch = new Stopwatch();
        int currentBytesRead = 0;

        Console.WriteLine("\n-----Reading By file Stream-----");

        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            stopWatch.Start();

            while ((currentBytesRead = await fileStream.ReadAsync(buffer, 0, bufferLength)) > 0)
            {
                bytesRead += currentBytesRead;
            }

            Console.WriteLine($"\nThe size of the file read by file stream: {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");

            stopWatch.Stop();
            Console.WriteLine($"\nThe time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using FileStream is : {stopWatch.ElapsedMilliseconds} Milliseconds");
        }
    }

    static async void ReadByBufferedStream(string fileName, int bufferLength)
    {
        byte[] buffer = new byte[bufferLength];
        int bytesRead = 0;
        Stopwatch stopWatch = new Stopwatch();
        int currentBytesRead = 0;

        Console.WriteLine("\n-----Reading By Buffered Stream-----");

        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferLength))
            {
                bytesRead = 0;
                stopWatch.Restart();

                while ((currentBytesRead = await bufferedStream.ReadAsync(buffer, 0, bufferLength))> 0)
                {
                    bytesRead += currentBytesRead;
                }

                Console.WriteLine($"\nThe size of the file read by buffered stream: {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
                stopWatch.Stop();

                Console.WriteLine($"\nThe time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using BufferedStream is : {stopWatch.ElapsedMilliseconds} Milliseconds");
            }
        }
    }

    static async void WriteByMemoryStream(string fileName, string processedFileName, int bufferLength)
    {
        Console.WriteLine("\n-------File is being processed by memory stream-------");
        byte[] buffer = new byte[bufferLength];
        using (FileStream fileReaderStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileWriterStream = new FileStream($"{processedFileName}.txt", FileMode.Create, FileAccess.Write))
                {
                    while (new FileInfo(fileName + ".txt").Length > new FileInfo(processedFileName + ".txt").Length)
                    {
                        await fileReaderStream.ReadAsync(buffer, 0, bufferLength);
                        string upperCaseString = Encoding.UTF8.GetString(buffer).ToUpper();
                        await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(upperCaseString));
                        memoryStream.WriteTo(fileWriterStream);
                        await memoryStream.FlushAsync();
                    }
                }
            }
        }

        Console.WriteLine("\nFile of UpperCase text is created by MemoryStream.");
        CheckFileContents(fileName, processedFileName);
    }

    static async void WriteByFileStream(string fileName, string processedFileName, int bufferLength)
    {
        Console.WriteLine("\n-------File is being processed by file Stream-------");

        using (FileStream fileReaderStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (FileStream fileWriterStream = new FileStream($"{processedFileName}.txt", FileMode.Append, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferLength];

                while (new FileInfo(fileName + ".txt").Length > new FileInfo(processedFileName + ".txt").Length)
                {
                    await fileReaderStream.ReadAsync(buffer, 0, bufferLength);
                    string upperCaseString = Encoding.UTF8.GetString(buffer).ToLower();
                    await fileWriterStream.WriteAsync(Encoding.UTF8.GetBytes(upperCaseString));
                }
            }
        }

        Console.WriteLine("\nFile of LowerCase text is created by FileStream.");
        CheckFileContents(fileName, processedFileName);
    }
}