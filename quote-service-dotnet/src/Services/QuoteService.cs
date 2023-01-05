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

        var iexUrl = $"https://sandbox.iexapis.com/stable/stock/{q}/quote?token=Tpk_c05ba4ad3b434f7ab8ffa87cfaab503a";
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
        var iexUrl = $"https://sandbox.iexapis.com/stable/stock/market/batch?symbols={symbols}&types=quote&token=Tpk_c05ba4ad3b434f7ab8ffa87cfaab503a";
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