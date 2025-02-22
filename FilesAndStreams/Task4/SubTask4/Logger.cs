using System.Text;

namespace Task4.SubTask4
{
    /// <summary>
    /// Class to define error logging methods
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// To log an error message to the file using file stream
        /// </summary>
        /// <param name="errorMessage">The error message that is to be logged</param>
        /// <param name="logFilePath">The filename to which the error message is to be logged</param>
        public static void LogError(string errorMessage, string logFilePath)
        {
            lock (logFilePath)
            {
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write))
                {
                    fileStream.Write(Encoding.UTF8.GetBytes(errorMessage));
                }
            }
        }
    }
}
