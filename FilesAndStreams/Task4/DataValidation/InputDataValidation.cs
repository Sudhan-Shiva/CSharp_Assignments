namespace Task4.DataValidation
{
    /// <summary>
    /// Class to define data validation methods
    /// </summary>
    internal static class InputDataValidation
    {
        /// <summary>
        /// To get a valid string which can be parsed to an integer
        /// </summary>
        /// <param name="inputString">The input string which is parsed</param>
        /// <returns>The valid integer</returns>
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
