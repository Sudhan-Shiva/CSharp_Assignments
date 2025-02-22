using System.Diagnostics;
using System.Text;
using Pastel;

namespace Task1.FileManager
{
    /// <summary>
    /// Class to define synchronous file handling methods using streams
    /// </summary>
    public class SynchronousFileHandler
    {
        /// <summary>
        /// To delete a file if it already exists
        /// </summary>
        /// <param name="FileName">The name of the file that is to be deleted</param>
        public void DeleteFileIfExists(string FileName)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }

        /// <summary>
        /// To create a large text file of size 1GB
        /// </summary>
        /// <param name="fileName">The name of the file to be created</param>
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

        /// <summary>
        /// To read the contents of a target file by BufferedStream
        /// </summary>
        /// <param name="fileName">The name of the file that is to be read</param>
        /// <returns>The number of bytes read from the file</returns>
        public int ReadByBufferedStream(string fileName)
        {
            using (FileStream fileStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    Stopwatch stopWatch = new Stopwatch();
                    int bufferLength = 1024 * 1024 * 1;
                    byte[] buffer = new byte[bufferLength];
                    int bytesRead = 0;
                    int currentBytesRead = 0;

                    Console.WriteLine("\n-----Reading By Buffered Stream-----".Pastel(ConsoleColor.Magenta));
                    stopWatch.Restart();

                    while ((currentBytesRead = bufferedStream.Read(buffer)) > 0)
                    {
                        bytesRead += currentBytesRead;
                    }

                    stopWatch.Stop();

                    Console.WriteLine($"\nThe size of the file read by buffered stream : ".Pastel(ConsoleColor.Yellow) + $"{bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                    Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using BufferedStream is : ".Pastel(ConsoleColor.Yellow) + $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));
                
                    return bytesRead;
                }
            }
        }

        /// <summary>
        /// To read the contents of a target file by FileStream
        /// </summary>
        /// <param name="fileName">The name of the file that is to be read</param>
        /// <returns>The number of bytes read from the file</returns>
        public int ReadByFileStream(string fileName)
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

                while ((currentBytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytesRead += currentBytesRead;
                }
                stopWatch.Stop();

                Console.WriteLine($"\nThe size of the file read by file stream : ".Pastel(ConsoleColor.Yellow) + $"{bytesRead / (1024.0 * 1024 * 1024)} Gigabytes".Pastel(ConsoleColor.Red));
                Console.WriteLine($"\nThe time elapsed to read the file in chunks of ".Pastel(ConsoleColor.Yellow) + $"{bufferLength / (1024.0 * 1024)} MegaBytes".Pastel(ConsoleColor.Red) + " using FileStream is : ".Pastel(ConsoleColor.Yellow) + $"{stopWatch.ElapsedMilliseconds} Milliseconds".Pastel(ConsoleColor.Red));

                return bytesRead;
            }
        }

        /// <summary>
        /// To write some processed data into a new file using memory stream
        /// </summary>
        /// <param name="fileName">The name of the file which contains the unprocessed data</param>
        /// <param name="processedFileName">The name of the file which is to be created to store the processed data</param>
        public void WriteByMemoryStream(string fileName, string processedFileName)
        {
            Console.WriteLine("\n-------File is being processed-------".Pastel(ConsoleColor.Magenta));

            using (FileStream fileReaderStream = new FileStream($"{fileName}.txt", FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (FileStream fileWriterStream = new FileStream($"{processedFileName}.txt", FileMode.Create, FileAccess.Write))
                    {
                        int bufferLength = 1024;
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

        /// <summary>
        /// To check the contents in the processed file and unprocessed file
        /// </summary>
        /// <param name="fileName">The name of the file which contains the unprocessed data</param>
        /// <param name="processedFileName">The name of the file which stores the processed data</param>
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
    }
}
