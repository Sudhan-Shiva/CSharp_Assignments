namespace Task4.SubTask3
{
    public class LockFile
    {
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
