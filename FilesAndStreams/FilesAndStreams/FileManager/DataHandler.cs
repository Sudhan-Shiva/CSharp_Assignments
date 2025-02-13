namespace FilesAndStreams.FileManager
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

        public void CreateDummyFile(string fileName, long length)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(length);
            }
        }
    }
}
