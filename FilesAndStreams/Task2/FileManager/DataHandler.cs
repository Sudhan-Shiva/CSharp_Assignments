namespace Task2.FileManager
{
    /// <summary>
    /// Class to perform file handling methods
    /// </summary>
    internal class DataHandler
    {
        /// <summary>
        /// To read the contents of a file
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>The contents of the file</returns>
        public string ReadFile(string path)
        {
            string userDetails = File.ReadAllText(path);
            return userDetails;
        }

        /// <summary>
        /// To write into a file
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <param name="content">The content to be written to the file</param>
        public void WriteFile(string path, string content)
        {
            File.AppendAllText(path, content);
        }
    }
}
