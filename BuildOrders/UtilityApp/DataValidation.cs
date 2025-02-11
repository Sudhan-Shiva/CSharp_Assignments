using Pastel;

namespace UtilityApp
{
    public static class DataValidation
    {
        /// <summary>
        /// Method to get a valid string which can be parsed to an integer
        /// </summary>
        /// <param name="inputString">String which is checked if it can be parsed to an integer</param>
        /// <returns>A valid integer</returns>
        public static int GetValidInteger(string inputString)
        {
            while (!int.TryParse(inputString, out int result))
            {
                Console.WriteLine($"\nThe given input is in invalid format and cannot be parsed to an integer !!!".Pastel(ConsoleColor.Red));
                Console.Write($"\nProvide a valid integer : ".Pastel(ConsoleColor.Yellow));
                inputString = Console.ReadLine();
            }

            return int.Parse(inputString);
        }
    }
}
