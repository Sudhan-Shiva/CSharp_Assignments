namespace IDisposableDemo.FileHandler
{
    public class FileReader : IDisposable
    {
        private StreamReader _streamReader;

        public FileReader(string fileName)
        {
            _streamReader = new StreamReader(fileName);
        }

        public string Read()
        {
            return _streamReader.ReadToEnd();
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
