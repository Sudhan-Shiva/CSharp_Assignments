namespace IDisposableDemo.FileHandler
{
    public class FileWriter : IDisposable
    {
        private StreamWriter _streamWriter;

        public FileWriter(string fileName)
        {
            _streamWriter = new StreamWriter(fileName);
        }

        public void Write(string fileText)
        {
            _streamWriter.WriteLine(fileText);
            _streamWriter.Flush();
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }
    }
}
