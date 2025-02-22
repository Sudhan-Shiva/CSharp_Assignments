using System.Text;

namespace Task4.SubTask2
{
    /// <summary>
    /// Class to define error logging methods
    /// </summary>
    public class Logger
    {
        private static string _logFilePath = "log.txt";

        /// <summary>
        /// To log an error message to the file using file stream
        /// </summary>
        /// <param name="errorMessage">The error message that is to be logged</param>
        public static void LogError(string errorMessage)
        {
            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(errorMessage));
            }
        }
    }
}
