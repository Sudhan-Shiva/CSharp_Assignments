using System.Diagnostics;
using System.Text;
using Pastel;

namespace Task2.FileManager
{
    public class AsynchronousFileHandler
    {
        public void DeleteFileIfExists(string FileName)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }

        public void CheckFileContents(string fileName, string processedFileName)
        {
            using (StreamReader testReader = new StreamReader($"{fileName}.txt"))
            {
                Console.WriteLine("\nThe previous first line in the file is : ".Pastel(ConsoleColor.Yellow) + testReader.ReadLine());
            }

            using (StreamReader testReader = new StreamReader($"{processedFileName}.txt"))
            {
                Console.WriteLine("The current first line after the file is processed : ".Pastel(ConsoleColor.Yellow) + testReader.ReadLine());
            }
        }

        public void CreateTextFile(string fileName)
        {
            DataHandler dataHandler = new DataHandler();

            Console.WriteLine("\n-------File is being created-------".Pastel(ConsoleColor.Magenta));
            do
            {
                dataHandler.WriteFile($"{fileName}.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
            } while (new FileInfo($"{fileName}.txt").Length < 1024.0 * 1024 * 1024);

            Console.WriteLine($"\nFile of size "+ $"{((double) new FileInfo($"{fileName}.txt").Length) / (1024.0 * 1024 * 1024)} GigaBytes ".Pastel(ConsoleColor.Red) + "is successfully created in the name "+$"{fileName}".Pastel(ConsoleColor.Red));
        }

        public async void ReadByFileStream(string fileName, int bufferLength)
        {
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;
            Stopwatch stopWatch = new Stopwatch();
            int currentBytesRead = 0;

            Console.WriteLine("\n-----Reading By file Stream-----".Pastel(ConsoleColor.Magenta));

            using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                stopWatch.Start();

                while ((currentBytesRead = await fileStream.ReadAsync(buffer)) > 0)
                {
                    bytesRead += currentBytesRead;
                }

                stopWatch.Stop();

                Console.WriteLine($"\nThe size of the file read by file stream : ".Pastel(ConsoleColor.Yellow)+ $"{bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{ bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using FileStream is : ".Pastel(ConsoleColor.Yellow)+ $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));
            }
        }

        public async void ReadByBufferedStream(string fileName, int bufferLength)
        {
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;
            Stopwatch stopWatch = new Stopwatch();
            int currentBytesRead = 0;

            Console.WriteLine("\n-----Reading By Buffered Stream-----".Pastel(ConsoleColor.Magenta));

            using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    bytesRead = 0;
                    stopWatch.Start();

                    while ((currentBytesRead = await bufferedStream.ReadAsync(buffer)) > 0)
                    {
                        bytesRead += currentBytesRead;
                    }

                    stopWatch.Stop();

                    Console.WriteLine($"\nThe size of the file read by buffered stream : ".Pastel(ConsoleColor.Yellow)+ $"{ bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                    Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using BufferedStream is : ".Pastel(ConsoleColor.Yellow) + $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));
                }
            }
        }

        public async void WriteByMemoryStream(string fileName, string processedFileName, int bufferLength)
        {
            Console.WriteLine("\n-------File is being processed by memory stream-------".Pastel(ConsoleColor.Magenta));
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

            Console.WriteLine($"\nFile of UpperCase text is created in the name " + $"{processedFileName}".Pastel(ConsoleColor.Red) + " by MemoryStream.");
            CheckFileContents(fileName, processedFileName);
        }

        public async void WriteByFileStream(string fileName, string processedFileName, int bufferLength)
        {
            Console.WriteLine("\n-------File is being processed by file Stream-------".Pastel(ConsoleColor.Magenta));

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

            Console.WriteLine("\nFile of LowerCase text is created in the name " + $"{processedFileName}".Pastel(ConsoleColor.Red) + " by FileStream.");
            CheckFileContents(fileName, processedFileName);
        }
    }
}
