namespace Task4.SubTask4
{
    /// <summary>
    /// Class to simulate multiple users logging errors to different files with file locks
    /// </summary>
    public class MultipleFileLog
    {
        /// <summary>
        /// To simulate multiple users logging errors to unique files simultaneously when file lock is applied
        /// </summary>
        public void ExecuteMultipleUserLoggingWithMultipleFiles()
        {
            Console.WriteLine("10 users are trying to log errors into the unique files !!!!");
            Parallel.For(0, 10, count =>
            {
                try
                {
                    Logger.LogError("\nError Logged : " + count, $"User{count}.txt");
                }
                catch (IOException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            });
        }
    }
}
