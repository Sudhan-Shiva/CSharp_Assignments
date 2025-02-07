using TestMemory.Model;

public class Program
{
    static void Main()
    {
        //Method to create a large array
        void createArray()
        {
            //Create a large array of 100000 products
            Product[] testArray = new Product[100000];

            // Assign product at each index of the array
            for (int index = 0; index < testArray.Length; index++)
            {
                testArray[index] = new Product("Name", index, index, "Category");
            }
        }
        
        //Method to perform calculation on multiple local variables
        void multipleCalculations()
        {
            int firstInteger = 1;
            int secondInteger = 2;
            int thirdInteger = 3;
            int fourthInteger = 4;

            //Creating new value type variables on each run of the loop
            for (int count = 0; count < 100000; count++)
            {
               int firstOutput = firstInteger + count;

               int secondOutput = firstInteger - count - firstOutput;

               int thirdOutput = firstInteger * firstOutput * secondOutput;
            }
        }

        //Introduce delay for a clear view of the changes in process memory graph
        Thread.Sleep(2000);

        //Call the multiple local variables calculations method
        multipleCalculations();
        Console.WriteLine("After Creation of Multiple Local Variables : Heap Size = "+GC.GetTotalMemory(false)+" bytes");

        //Introduce delay for a clear view of the changes in process memory graph
        Thread.Sleep(2000);

        //Call the Large array method
        createArray();
        Console.WriteLine("After creation of the large array : Heap Size = "+GC.GetTotalMemory(false)+" bytes");

        Console.ReadKey();
    }
}
