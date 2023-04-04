using System;
using Newtonsoft.Json;

public class IexQuote
{

    public string symbol { get; set; }
    public string companyName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal open { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal close { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Int64 closeTime { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal high { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal low { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal latestPrice { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Int64 latestUpdate { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string latestSource { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal change { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal changePercent { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal avgTotalVolume { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Decimal marketCap { get; set; }

}
