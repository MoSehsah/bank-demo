using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class QuoteService
{
    private static HttpClient Client = new HttpClient();

    public async static Task<Quote> GetIexQuoteAsync(string q)
    {
        IexQuote iexResult = null;

        var iexUrl = $"https://cloud.iexapis.com/stable/stock/{q}/quote?token=sk_2e5aaea4cc2d43e2b56b8b1c6745f0a0";
        var result = await Client.GetAsync(iexUrl);
        if (result.IsSuccessStatusCode)
        {
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            iexResult = await result.Content.ReadAsAsync<IexQuote>();
        }
        Quote quoteObj = QuoteMapper.INSTANCE.mapFromIexQuote(iexResult);
        return quoteObj;
    }

    public async static Task<List<Quote>> GetIexQuotesAsync(string symbols)
    {
        IexBatchQuote iexResult = null;

        List<Quote> response = new List<Quote>();
        var iexUrl = $"https://cloud.iexapis.com/stable/stock/market/batch?symbols={symbols}&types=quote&token=sk_2e5aaea4cc2d43e2b56b8b1c6745f0a0";
        var result = await Client.GetAsync(iexUrl);
        if (result.IsSuccessStatusCode)
        {
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            iexResult = await result.Content.ReadAsAsync<IexBatchQuote>();
        }
        foreach (var symbol in iexResult.Keys)

        {
            response.Add(QuoteMapper.INSTANCE.mapFromIexQuote(iexResult[symbol]["quote"]));
        }
        return response;
    }
}