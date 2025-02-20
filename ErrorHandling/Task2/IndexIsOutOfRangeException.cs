/// <summary>
/// Handle the IndexOutOfRangeException
/// </summary>
public class IndexIsOutOfRangeException
{
    /// <summary>
    /// Print appropriate messages for IndexOutOfRange Exception.
    /// </summary>
    public void ExecuteTask2()
    {
        int[] testArray = { 1, 2, 3, 4, 5 };
        Console.Write("Give the index of the element to be checked : ");
        int inputIndex = int.Parse(Console.ReadLine());

        try
        {
            int elementPresent = returnIndex(testArray, inputIndex);
            Console.WriteLine($"The element at Index {inputIndex} is {elementPresent}");
        }

        catch (System.IndexOutOfRangeException indexException)
        {
            try
            {
                throw new Exception(indexException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\nThe array contains only {testArray.Length} elements.\nException Occured : {exception.Message}");
            }
        }

        finally
        {
            Console.WriteLine("\nThe block has been executed.");
        }
    }

    private int returnIndex(int[] testArray, int testIndex)
    {
        return testArray[testIndex];
    }
}
