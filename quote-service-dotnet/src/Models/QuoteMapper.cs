
using System;

public class QuoteMapper {
    public static QuoteMapper INSTANCE = new QuoteMapper();

    private QuoteMapper() :base(){
    }

    public Quote mapFromIexQuote(IexQuote iexQuote) {
        if (iexQuote == null) {
            return null;
        }

        Quote mappedQuote = new Quote();
        mappedQuote.Symbol =iexQuote.symbol;
        mappedQuote.Name = iexQuote.companyName;
        mappedQuote.Open = iexQuote.open;
        mappedQuote.High = iexQuote.high;
        mappedQuote.Low = iexQuote.low;
        mappedQuote.Change = iexQuote.change;
        mappedQuote.ChangePercent = (float) iexQuote.changePercent;
        mappedQuote.MarketCap = (float) iexQuote.marketCap;
        if ("Previous close".Equals(iexQuote.latestSource)) {
            mappedQuote.LastPrice = iexQuote.close;
            mappedQuote.Timestamp = new DateTime(iexQuote.closeTime);
        } else {
            mappedQuote.LastPrice = iexQuote.latestPrice;
            mappedQuote.Timestamp = new DateTime(iexQuote.latestUpdate);
        }
        mappedQuote.Status = "SUCCESS";
        mappedQuote.Volume = (int) Math.Round((double) iexQuote.avgTotalVolume);

        return mappedQuote;
    }
}
