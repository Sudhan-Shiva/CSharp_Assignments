namespace Task2.FileManager
{
    public class DataHandler
    {
        public string ReadFile(string path)
        {
            string userDetails = File.ReadAllText(path);
            return userDetails;
        }

        public void WriteFile(string path, string content)
        {          
           File.AppendAllText(path, content);
        }
    }
}
