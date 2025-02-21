using System.Text;

namespace Task4.SubTask1
{
    public class Logger
    {
        private static string _logFilePath = "log.txt";

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
