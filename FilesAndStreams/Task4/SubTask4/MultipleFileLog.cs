namespace Task4.SubTask4
{
    public class MultipleFileLog
    {
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
