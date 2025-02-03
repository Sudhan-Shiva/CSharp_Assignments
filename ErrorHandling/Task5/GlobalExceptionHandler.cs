/// <summary>
/// Throw new exceptions which are handled in Global Try-Catch Block for any unhandled exceptions thrown.
/// </summary>
public class GlobalExceptionHandler
{
    public int ExecuteTask5(string userInput)
    {
        if (int.TryParse(userInput, out int result))
        {
            return int.Parse(userInput);
        }

        throw new Exception($"The given input '{userInput}' is in invalid Format and cannot be parsed into an integer.");
    }
}
