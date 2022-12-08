using System;
using Newtonsoft.Json;

public class IexQuote {

    public string symbol{ get; set; }
    public string companyName{ get; set; }
    public Decimal open{ get; set; }
    public Decimal close{ get; set; }
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public Int64 closeTime{ get; set; }
    public Decimal high{ get; set; }
    public Decimal low{ get; set; }
    public Decimal latestPrice{ get; set; }
    public Int64 latestUpdate{ get; set; }
    public string latestSource{ get; set; }
    public Decimal change{ get; set; }
    public Decimal changePercent{ get; set; }
    public Decimal avgTotalVolume{ get; set; }
    public Decimal marketCap{ get; set; }

}
