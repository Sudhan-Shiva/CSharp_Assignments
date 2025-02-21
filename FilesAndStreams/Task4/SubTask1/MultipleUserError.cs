namespace Task4.SubTask1
{
    public class MultipleUserError
    {
        public void ExecuteMultipleUserLogging()
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
