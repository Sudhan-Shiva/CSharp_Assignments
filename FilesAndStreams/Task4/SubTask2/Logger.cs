using System.Text;

namespace Task4.SubTask2
{
    public class Logger
    {
        private static string _logFilePath = "log.txt";

        public static void LogError(string errorMessage)
        {
            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(errorMessage));
            }
        }
    }
}
