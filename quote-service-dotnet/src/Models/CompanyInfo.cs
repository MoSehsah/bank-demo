using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class CompanyInfo
{

    [JsonPropertyName("Symbol")]
    public string Symbol { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Exchange")]
    public string Exchange { get; set; }


}
