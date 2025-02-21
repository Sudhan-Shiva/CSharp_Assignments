using System.Diagnostics;
using System.Text;
using Pastel;

namespace Task1.FileManager
{
    public class SynchronousFileHandler
    {
        public void CheckFileContent(string fileName, string processedFileName)
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

        public void WriteByMemoryStream(string fileName, string processedFileName)
        {
            Console.WriteLine("\n-------File is being processed-------".Pastel(ConsoleColor.Magenta));

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

            Console.WriteLine($"\nFile of UpperCase text is created in the name " + $"{processedFileName}".Pastel(ConsoleColor.Red) + " by MemoryStream.");
        }

        public void ReadByBufferedStream(string fileName)
        {
            Stopwatch stopWatch = new Stopwatch();
            int bufferLength = 1024 * 1024 * 1;
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;
            int currentBytesRead = 0;

            using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    Console.WriteLine("\n-----Reading By Buffered Stream-----".Pastel(ConsoleColor.Magenta));
                    stopWatch.Restart();

                    while ((currentBytesRead = bufferedStream.Read(buffer)) > 0)
                    {
                        bytesRead += currentBytesRead;
                    }

                    stopWatch.Stop();

                    Console.WriteLine($"\nThe size of the file read by buffered stream : ".Pastel(ConsoleColor.Yellow) + $"{bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                    Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using BufferedStream is : ".Pastel(ConsoleColor.Yellow) + $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));
                }
            }
        }

        public void ReadByFileStream(string fileName)
        {
            using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                Stopwatch stopWatch = new Stopwatch();
                int bufferLength = 1024 * 1024 * 1;
                byte[] buffer = new byte[bufferLength];
                int bytesRead = 0;
                int currentBytesRead = 0;

                Console.WriteLine("\n-----Reading By File Stream-----".Pastel(ConsoleColor.Magenta));
                stopWatch.Start();

                while ((currentBytesRead = fileStream.Read(buffer)) > 0)
                {
                    bytesRead += currentBytesRead;
                }
                stopWatch.Stop();

                Console.WriteLine($"\nThe size of the file read by file stream : ".Pastel(ConsoleColor.Yellow) + $"{bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using FileStream is : ".Pastel(ConsoleColor.Yellow) + $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));
            }
        }

        public void CreateLargeTextFile(string fileName)
        {
            DataHandler dataHandler = new DataHandler();

            Console.WriteLine("\n-------File is being created-------".Pastel(ConsoleColor.Magenta));

            do
            {
                dataHandler.WriteFile($"{fileName}.txt", dataHandler.ReadFile("../../../../Shakespeare.txt"));
            } while (new FileInfo($"{fileName}.txt").Length < 1024.0 * 1024 * 1024);

            Console.WriteLine($"\nFile of size " + $"{((double)new FileInfo($"{fileName}.txt").Length) / (1024.0 * 1024 * 1024)} GigaBytes ".Pastel(ConsoleColor.Red) + "is successfully created in the name " + $"{fileName}".Pastel(ConsoleColor.Red));
        }
    }
}
