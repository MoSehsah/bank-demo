using System;
using System.Net.Http;
using System.Threading.Tasks;

public class QuoteService
{
    private static HttpClient Client = new HttpClient();

    public async static Task<IexQuote> GetIexQuoteAsync(string q)
    {
        IexQuote iexResult = null;

        var iexUrl = $"https://sandbox.iexapis.com/stable/stock/{q}/quote?token=Tpk_c05ba4ad3b434f7ab8ffa87cfaab503a";
        var result = await Client.GetAsync(iexUrl);
        if (result.IsSuccessStatusCode)
        {
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            iexResult = await result.Content.ReadAsAsync<IexQuote>();
        }

        return iexResult;
    }
}