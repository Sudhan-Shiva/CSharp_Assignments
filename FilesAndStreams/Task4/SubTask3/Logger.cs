using System.Text;

namespace Task4.SubTask3
{
    public class Logger
    {
        private static string _logFilePath = "log.txt";

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
