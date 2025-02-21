namespace Task4.DataValidation
{
    public static class InputDataValidation
    {
        public static int GetValidInteger(string inputString)
        {
            int result = 0;

            while(!int.TryParse(inputString, out result))
            {
                Console.Write("\nProvide a valid input : ");
                inputString = Console.ReadLine();
            }

            return result;
        }
    }
}
