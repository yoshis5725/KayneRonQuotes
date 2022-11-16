using Newtonsoft.Json.Linq;

namespace KayneVsRonQuotes;

public static class QuoteGenerator
{
    private static readonly HttpClient HttpClient = new ();

    public static void KayneQuote()
    {
        var kayneUrl = "https://api.kanye.rest";
        var kayneResponse = HttpClient.GetStringAsync(kayneUrl).Result;
        var kayneQuote = JObject.Parse(kayneResponse).GetValue("quote")?.ToString();
        
        Console.WriteLine($"Kayne says:\n {kayneQuote}\n");
    }

    public static void RonSwansonQuote()
    {
        const string ronSwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var ronSwansonResponse = HttpClient.GetStringAsync(ronSwansonUrl).Result;
        var ronQuote = JArray.Parse(ronSwansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
        
        Console.WriteLine($"Ron Swanson says:\n {ronQuote}\n");
    }
}