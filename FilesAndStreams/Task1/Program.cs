using System.Diagnostics;
using Task1.FileManager;

public class Program
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        DataHandler dataHandler = new DataHandler();

        Console.Write("Provide the name of the file to be created : ");
        string fileName = Console.ReadLine();

        Console.WriteLine("\n-------File is being created-------");
        do
        {
            dataHandler.WriteFile($"{fileName}.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
        } while (new FileInfo($"{fileName}.txt").Length < 1024.0 * 1024 * 1024);

        Console.WriteLine($"\nFile of size {File.ReadAllText($"{fileName}.txt").Length/(1024.0*1024*1024)} Gigabytes is successfully created.");

        char[] buffer = null;
        int bufferLength = 1024 * 1024;
        int bytesRead = 0;

        Stopwatch stopWatch = new Stopwatch();

        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                stopWatch.Start();

                while (!streamReader.EndOfStream)
                {
                    buffer = new char[bufferLength];
                    bytesRead += streamReader.Read(buffer, 0, bufferLength);
                }

                Console.WriteLine($"\nThe size of the file read : {bytesRead / (1024.0 * 1024 * 1024)} Gigabytes");
                stopWatch.Stop();

                Console.WriteLine($"The time elapsed to read the file in chunks of {bufferLength / (1024.0 * 1024)} MegaBytes using FileStream is : {stopWatch.Elapsed} seconds");
            }
        }

        using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
        {

            using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferLength))
            {
                using (StreamReader streamReader = new StreamReader(bufferedStream))
                {
                    bytesRead = 0;
                    stopWatch.Restart();

                    while (! streamReader.EndOfStream)
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

        Console.Write("\nProvide the name of the file to be created after processing : ");
        string processedFileName = Console.ReadLine();

        Console.WriteLine("\n-------File is being processed-------");

        using (MemoryStream memoryStream = new MemoryStream(bufferLength))
        {
            using (StreamWriter streamWriter = new StreamWriter(memoryStream))
            {
                using (StreamReader streamReader = new StreamReader($"{fileName}.txt"))
                {
                    using (FileStream fileWriterStream = new FileStream($"{processedFileName}.txt", FileMode.Append, FileAccess.Write))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string outputData = streamReader.ReadToEnd().ToUpper();
                            streamWriter.Write(outputData);
                            memoryStream.WriteTo(fileWriterStream);
                        }
                    }
                }
            }

            using (StreamReader testReader = new StreamReader($"{fileName}.txt"))
            {
                Console.WriteLine("\nThe previous first line in the file is : " + testReader.ReadLine());
            }

            using (StreamReader testReader = new StreamReader($"{processedFileName}.txt"))
            {
                Console.WriteLine("The current first line after the file is processed by MemoryStream is : " + testReader.ReadLine());
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine("\nPress any key to exit....");
            Console.ReadKey();
        }
    }
}