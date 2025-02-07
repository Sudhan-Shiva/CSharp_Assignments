namespace IDisposableDemo.FileHandler
{
    public class FileWriter : IDisposable
    {
        private StreamWriter _streamWriter;

        public FileWriter(string fileName)
        {
            _streamWriter = new StreamWriter(fileName);
        }

        //Create method to write contents into the file
        public void Write(string fileText)
        {
            _streamWriter.WriteLine(fileText);
            _streamWriter.Flush();
        }

        //Implement the dispose method of the IDisposable interface
        public void Dispose()
        {
            _streamWriter.Dispose();
        }
    }
}
