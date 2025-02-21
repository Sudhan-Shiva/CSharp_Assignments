using Task4.SubTask1;
using Task4.Contents;
using Task4.SubTask2;
using Task4.SubTask3;
using Task4.SubTask4;
using Task4.DataValidation;

public class Program
{
    static void Main()
    {
        SubTaskList chosenSubTask = GetSubTaskToBeExecuted();

        ExecuteTask4(chosenSubTask);

        Console.WriteLine("Press any key to exit....");
        Console.ReadKey();
    }

    private static void ExecuteTask4(SubTaskList chosenSubTask)
    {
        while (chosenSubTask != SubTaskList.Exit)
        {
            switch (chosenSubTask)
            {
                case SubTaskList.SubTask1:
                    MultipleUserError multipleUserError = new MultipleUserError();
                    multipleUserError.ExecuteMultipleUserLogging();
                    break;

                case SubTaskList.SubTask2:
                    DirectAccessOfFile directAccessOfFile = new DirectAccessOfFile();
                    directAccessOfFile.WriteDirectlyToFile();
                    break;

                case SubTaskList.SubTask3:
                    LockFile lockFile = new LockFile();
                    lockFile.ExecuteMultipleUserLoggingWithLock();
                    break;

                case SubTaskList.SubTask4:
                    MultipleFileLog multipleFileLog = new MultipleFileLog();
                    multipleFileLog.ExecuteMultipleUserLoggingWithMultipleFiles();
                    break;

                default:
                    Console.WriteLine("The input provided is out of bounds !!!!");
                    Console.WriteLine("\n-----Returning to main menu-----");

                    Thread.Sleep(1000);
                    Console.Clear();

                    chosenSubTask = GetSubTaskToBeExecuted();
                    ExecuteTask4(chosenSubTask);
                    break;
            }

            Console.WriteLine("\nPress any key to perform the next action...");
            Console.ReadKey();
            Console.Clear();
            chosenSubTask = GetSubTaskToBeExecuted();
        }
    }

    private static SubTaskList GetSubTaskToBeExecuted()
    {
        Console.WriteLine("\n-----Welcome-----");

        Console.WriteLine($"\n[0] {SubTaskList.SubTask1}");
        Console.WriteLine($"[1] {SubTaskList.SubTask2}");
        Console.WriteLine($"[2] {SubTaskList.SubTask3}");
        Console.WriteLine($"[3] {SubTaskList.SubTask4}");
        Console.WriteLine($"[4] {SubTaskList.Exit}");
        
        Console.Write("\nChoose the SubTask to be executed : ");
        SubTaskList chosenSubTask = (SubTaskList) InputDataValidation.GetValidInteger(Console.ReadLine());
        Console.WriteLine();

        return chosenSubTask;
    }
}