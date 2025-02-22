namespace Task4.SubTask3
{
    /// <summary>
    /// Class to simulate multiple users logging errors with file locks
    /// </summary>
    public class LockFile
    {
        /// <summary>
        /// To simulate multiple users logging errors to the same file simultaneously when file lock is applied
        /// </summary>
        public void ExecuteMultipleUserLoggingWithLock()
        {
            Console.WriteLine("10 users are trying to log errors into the file !!!!");
            Console.WriteLine("\n-----Lock is applied-----");
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
