using Pastel;
using Newtonsoft.Json;

/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static async Task Main()
    {
        var result = await MethodC();
        Console.WriteLine("Result of MethodC : ".Pastel(ConsoleColor.Yellow) + result);

        Console.ReadKey();
    }

    /// <summary>
    /// To simulate a CPU-bound operation performing a complex calculation.
    /// </summary>
    /// <returns>The result of the mathematical calculation</returns>
    static async Task<int> MethodA()
    {
        return await Task.Run(() =>
        {
            int result = 0;
            Console.WriteLine("MethodA => ".Pastel(ConsoleColor.Yellow) + "Calculating result of complex mathematical operation...");
            for (int i = 1; i <= 100; i++)
            {
                result += (i * i);
            }

            Task.Delay(1000);
            Console.WriteLine("Result of MethodA : ".Pastel(ConsoleColor.Yellow) + result);
            return result;
        });
    }

    /// <summary>
    /// To simulate an async operation making a web service call
    /// </summary>
    /// <returns>The content of the URL</returns>
    static async Task<string> MethodB()
    {
        int result = await MethodA();

        using (HttpClient client = new HttpClient())
        {
            string url = $"https://jsonplaceholder.typicode.com/todos/{result % 10 + 1}";
            Console.WriteLine("\nMethodB => ".Pastel(ConsoleColor.Yellow) + $"Fetching data from {url}");

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string urlContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Result of MethodB : ".Pastel(ConsoleColor.Yellow) + "Returns dummy json serialized content from the given URL");
            Console.WriteLine(urlContent);
            return urlContent;
        }
    }

    /// <summary>
    /// To parse a JSON response and extract the number of key-value pairs
    /// </summary>
    /// <returns>The number of key-value pairs in the response body</returns>
    static async Task<int> MethodC()
    {
        string result = await MethodB();
        Console.WriteLine("\nMethodC => ".Pastel(ConsoleColor.Yellow) + "Calculating the number of Key-Value pairs from the URL Content...");
        var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
        return keyValuePairs.Count;
    }
}
