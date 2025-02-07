using TestMemory.Model;

public class Program
{
    static void Main()
    {
        void createArray()
        {
            Product[] testArray = new Product[100000];

            for (int index = 0; index < testArray.Length; index++)
            {
                testArray[index] = new Product("Name", index, index, "Category");
            }
        }
        
        void multipleCalculations()
        {
            int firstInteger = 1;
            int secondInteger = 2;
            int thirdInteger = 3;
            int fourthInteger = 4;

            for (int count = 0; count < 100000; count++)
            {
               int firstOutput = firstInteger + count;

               int secondOutput = firstInteger - count - firstOutput;

               int thirdOutput = firstInteger * firstOutput * secondOutput;
            }
        }

        Thread.Sleep(2000);
        multipleCalculations();
        Console.WriteLine("After Creation of Multiple Local Variables : Heap Size = "+GC.GetTotalMemory(false)+" bytes");

        Thread.Sleep(2000);
        createArray();
        Console.WriteLine("After creation of the large array : Heap Size = "+GC.GetTotalMemory(false)+" bytes");

        Console.ReadKey();
    }
}
