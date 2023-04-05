using System;
using System.Text.Json.Serialization;

public class Quote {

    [JsonPropertyName("Status")]
	public string Status { get; set; }
	[JsonPropertyName("Name")]
	public string Name { get; set; }
	[JsonPropertyName("Symbol")]
	public string Symbol { get; set; }
	[JsonPropertyName("LastPrice")]
	public decimal LastPrice { get; set; }
	[JsonPropertyName("Change")]
	public decimal Change { get; set; }
	[JsonPropertyName("ChangePercent")]
	public float ChangePercent { get; set; }
	[JsonPropertyName("Timestamp")]
	// @JsonFormat(shape=JsonFormat.Shape.string, pattern="EEE MMM dd HH:mm:ss zzzXXX yyyy", locale="ENGLISH")
	public DateTime Timestamp { get; set; }
	[JsonPropertyName("MSDate")]
	public float MSDate { get; set; }
	[JsonPropertyName("MarketCap")]
	public float MarketCap { get; set; }
	[JsonPropertyName("Volume")]
	public int Volume { get; set; }
	[JsonPropertyName("ChangeYTD")]
	public float ChangeYTD { get; set; }
	[JsonPropertyName("ChangePercentYTD")]
	public float ChangePercentYTD { get; set; }
	[JsonPropertyName("High")]
	public decimal High { get; set; }
	[JsonPropertyName("Low")]
	public decimal Low { get; set; }
	[JsonPropertyName("Open")]
	public decimal Open { get; set; }
	[JsonPropertyName("Currency")]
	public string Currency = "USD" ;
}