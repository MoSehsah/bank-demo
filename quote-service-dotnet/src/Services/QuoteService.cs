using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class QuoteService
{
    private static HttpClient Client = new HttpClient();

    public async static Task<Quote> GetIexQuoteAsync(string q)
    {
        if (Boolean.Parse(Environment.GetEnvironmentVariable("AIRGAPPED") ?? "false"))
        {
            Console.WriteLine("AIRGAPPED environment variable is set, returning specific value");
            List<Quote> quotes = new List<Quote>();
            Quote quote = new Quote();
            quote.Symbol = "VMW";
            quote.Name = "Vmware Inc. - Class A";
            quote.LastPrice = 123.94m;
            quote.Change = -1.07m;
            quote.ChangeYTD = 0;
            quote.ChangePercentYTD = 0;
            quote.High = 0;
            quote.Low = 0;
            quote.Open = 0;
            quote.Currency = "USD";
            quote.Status = "SUCCESS";
            quote.ChangePercent = -0.00371f;
            quote.Timestamp = DateTime.ParseExact("Mon Apr 03 20:00:00 UTC 2023", "ddd MMM dd HH:mm:ss UTC yyyy", null);
            quote.MarketCap = 53106230000f;
            quote.Volume = 1274700;
            quotes.Add(quote);
            return quotes[0];
        }
        
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
        
        if (Boolean.Parse(Environment.GetEnvironmentVariable("AIRGAPPED") ?? "false"))
        {
            Console.WriteLine("AIRGAPPED environment variable is set, returning specific value");
            List<Quote> quotes = new List<Quote>();
            Quote quote = new Quote();
            quote.Symbol = "VMW";
            quote.Name = "Vmware Inc. - Class A";
            quote.LastPrice = 123.94m;
            quote.Change = -1.07m;
            quote.ChangeYTD = 0;
            quote.ChangePercentYTD = 0;
            quote.High = 0;
            quote.Low = 0;
            quote.Open = 0;
            quote.Currency = "USD";
            quote.Status = "SUCCESS";
            quote.ChangePercent = -0.00371f;
            quote.Timestamp = DateTime.ParseExact("Mon Apr 03 20:00:00 UTC 2023", "ddd MMM dd HH:mm:ss UTC yyyy", null);
            quote.MarketCap = 53106230000f;
            quote.Volume = 1274700;
            quotes.Add(quote);
            return quotes;
        }
        
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

    public async static Task<List<CompanyInfo>> GetCompanyInfo(String name)
    {
        IexQuote iexResult = null;
        var iexUrl = $"https://cloud.iexapis.com/stable/stock/{name}/quote?token=sk_2e5aaea4cc2d43e2b56b8b1c6745f0a0";
        var result = await Client.GetAsync(iexUrl);
        if (result.IsSuccessStatusCode)
        {
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            iexResult = await result.Content.ReadAsAsync<IexQuote>();
        }
        List<CompanyInfo> response = new List<CompanyInfo>();

        response.Add(CompanyMapper.INSTANCE.mapFromIexQuote(iexResult));
        return response;

    }
}

