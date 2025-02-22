using System.Text;

namespace Task4.SubTask3
{
    /// <summary>
    /// Class to define error logging methods
    /// </summary>
    public class Logger
    {
        private static string _logFilePath = "log.txt";

        /// <summary>
        /// To log an error message to the file using file stream and by applying lock to prevent the access of the file
        /// </summary>
        /// <param name="errorMessage">The error message that is to be logged</param>
        public static void LogError(string errorMessage)
        {
            lock (_logFilePath)
            {
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
                {
                    fileStream.Write(Encoding.UTF8.GetBytes(errorMessage));
                }
            }
        }
    }
}
