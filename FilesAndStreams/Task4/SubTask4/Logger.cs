using System.Text;

namespace Task4.SubTask4
{
    public class Logger
    {
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
