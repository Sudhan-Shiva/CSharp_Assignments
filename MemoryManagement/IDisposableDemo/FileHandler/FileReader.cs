namespace IDisposableDemo.FileHandler
{
    public class FileReader : IDisposable
    {
        private StreamReader _streamReader;

        public FileReader(string fileName)
        {
            _streamReader = new StreamReader(fileName);
        }

        //Create method to read contents of the file
        public string Read()
        {
            return _streamReader.ReadToEnd();
        }

        //Implement the dispose method of the IDisposable interface
        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
