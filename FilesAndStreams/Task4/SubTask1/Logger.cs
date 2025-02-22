using System.Text;

namespace Task4.SubTask1
{
    /// <summary>
    /// Class to define error logging methods
    /// </summary>
    public class Logger
    {
        private static string _logFilePath = "log.txt";

        /// <summary>
        /// To log an error message to the file using memory stream
        /// </summary>
        /// <param name="errorMessage">The error message that is to be logged</param>
        public static void LogError(string errorMessage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);

                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
    }
}
