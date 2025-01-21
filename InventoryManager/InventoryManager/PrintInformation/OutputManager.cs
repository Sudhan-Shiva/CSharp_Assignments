namespace InventoryManager.PrintInformation
{
    public static class OutputManager
    {
        //Method to print that the given input is invalid
        public static void PrintInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
        }

        //Method to Print the user options and generate the user interface
        public static string PrintUserOptions()
        {
            Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[Q]uickSort the Product List\n[D]elete the Product\n[E]xit the Product List\n");
            Console.Write("Type your Choice: ");
            return Console.ReadLine();
        }

        public static void PrintListIsEmpty()
        {
            Console.WriteLine("The Product List is Empty");
        }

    }
}