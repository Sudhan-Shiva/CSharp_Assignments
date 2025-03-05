using System;

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
        string url = "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)";

        try
        {
            var urlContent = await GetUrlContent(url);
            Console.WriteLine(urlContent);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }

        Console.ReadKey();
    }

    /// <summary>
    /// To download the URL content using HttpClient class
    /// </summary>
    /// <param name="url">The URL from which the content is to be downloaded</param>
    /// <returns>The content from the URL</returns>
    private static async Task<string> GetUrlContent(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
