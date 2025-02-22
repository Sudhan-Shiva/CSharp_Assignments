namespace Task4.SubTask2
{
    /// <summary>
    /// Class to simulate multiple users logging errors
    /// </summary>
    public class DirectAccessOfFile
    {
        /// <summary>
        /// To simulate multiple users logging errors to the same file simultaneously through file stream
        /// </summary>
        public void WriteDirectlyToFile()
        {
            Console.WriteLine("10 users are trying to log errors into the file !!!!\n");
            Parallel.For(0, 10, count =>
            {
                try
                {
                    Logger.LogError("\nError Logged : " + count);
                }
                catch (IOException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            });
        }
    }
}
