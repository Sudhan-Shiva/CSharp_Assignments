public class Program
{
    static async Task Main(string[] args)
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