using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json;
using System.Text;

namespace WebApi.Controllers
{
    [Route("v1")]
    [ApiController]
    public class quotesController : ControllerBase

    {
        // GET api/values/5
        private static HttpClient Client = new HttpClient();
        [HttpGet("{quotes}")]
        public ActionResult<string> Details(string q)
        {
            var iexUrl = $"https://sandbox.iexapis.com/stable/stock/{q}/quote?token=Tpk_c05ba4ad3b434f7ab8ffa87cfaab503a";
            var result = Client.GetAsync(iexUrl);
            var iexResult = result.Result.Content.ReadAsStringAsync().Result;
            JObject jo = JObject.Parse(iexResult);
            jo.Add("Status","SUCCESS");
            jo.Add("Name",jo.Property("companyName").Value);
            jo.Property("companyName").Remove();
            jo.Add("Symbol",jo.Property("symbol").Value);
            jo.Property("symbol").Remove();
            jo.Add("LastPrice",jo.Property("latestPrice").Value);
            jo.Property("latestPrice").Remove();
            jo.Add("Change",jo.Property("change").Value);
            jo.Property("change").Remove();
            jo.Add("ChangePercent",jo.Property("changePercent").Value);
            jo.Property("changePercent").Remove();
            var latestUpdateDouble = Convert.ToDouble(jo.Property("latestUpdate").Value);
            var latestUpdateDate = (DateTimeOffset.UnixEpoch.AddMilliseconds(latestUpdateDouble));
            //jo.Add("Timestamp",latestUpdateDate);
            var latestUpdateDateCustom = latestUpdateDate.ToString("ddd MMM dd HH:mm:ss UTCZ yyyy");
            jo.Add("Timestamp",latestUpdateDateCustom);
            jo.Add("MSDate",null);
            jo.Add("MarketCap",jo.Property("marketCap").Value);
            jo.Property("marketCap").Remove();
            jo.Add("Volume",jo.Property("avgTotalVolume").Value);
            jo.Property("volume").Remove();
            jo.Add("ChangeYTD",null);
            jo.Add("ChangePercentYTD",null);
            jo.Add("High",jo.Property("high").Value);
            jo.Property("high").Remove();
            jo.Add("Low",jo.Property("low").Value);
            jo.Property("low").Remove();
            jo.Add("Open",jo.Property("open").Value);
            jo.Property("open").Remove();
            jo.Add("Currency",jo.Property("currency").Value);
            jo.Property("currency").Remove();
            jo.Property("avgTotalVolume").Remove();
            jo.Property("calculationPrice").Remove();
            jo.Property("close").Remove();
            jo.Property("closeSource").Remove();
            jo.Property("closeTime").Remove();
            jo.Property("delayedPrice").Remove();
            jo.Property("delayedPriceTime").Remove();
            jo.Property("extendedChange").Remove();
            jo.Property("extendedChangePercent").Remove();
            jo.Property("extendedPrice").Remove();
            jo.Property("highSource").Remove();
            jo.Property("highTime").Remove();
            jo.Property("iexAskPrice").Remove();
            jo.Property("iexAskSize").Remove();
            jo.Property("iexBidPrice").Remove();
            jo.Property("iexBidSize").Remove();
            jo.Property("iexClose").Remove();
            jo.Property("iexCloseTime").Remove();
            jo.Property("iexLastUpdated").Remove();
            jo.Property("iexMarketPercent").Remove();
            jo.Property("iexOpen").Remove();
            jo.Property("iexOpenTime").Remove();
            jo.Property("iexRealtimePrice").Remove();
            jo.Property("iexRealtimeSize").Remove();
            jo.Property("iexVolume").Remove();
            jo.Property("lastTradeTime").Remove();
            jo.Property("latestSource").Remove();
            jo.Property("latestTime").Remove();
            jo.Property("oddLotDelayedPrice").Remove();
            jo.Property("oddLotDelayedPriceTime").Remove();
            jo.Property("openSource").Remove();
            jo.Property("primaryExchange").Remove();
            jo.Property("ytdChange").Remove();
            jo.Property("lowSource").Remove();
            jo.Property("extendedPriceTime").Remove();
            jo.Property("latestUpdate").Remove();
            jo.Property("latestVolume").Remove();
            jo.Property("lowTime").Remove();
            jo.Property("openTime").Remove();
            jo.Property("previousClose").Remove();
            jo.Property("previousVolume").Remove();
            jo.Property("peRatio").Remove();
            jo.Property("week52High").Remove();
            jo.Property("week52Low").Remove();
            jo.Property("isUSMarketOpen").Remove();
            //iexResult = jo.ToString();
            iexResult = JsonConvert.SerializeObject(jo);
            
            var len = Convert.ToInt32(iexResult.Length+1);
            var str = iexResult.Insert(0, "[").Insert(len,"]");
            string str2 = "[{\"Status\":\"SUCCESS\",\"Name\":\"Vmware Inc. - Class A\",\"Symbol\":\"VMW\",\"LastPrice\":120.52,\"Change\":0.19,\"ChangePercent\":0.0016,\"Timestamp\":\"Sat Aug 26 01:20:27 UTCZ 2023\",\"MSDate\":null,\"MarketCap\":5.1572113E10,\"Volume\":1257885,\"ChangeYTD\":null,\"ChangePercentYTD\":null,\"High\":0,\"Low\":0,\"Open\":0,\"Currency\":\"USD\"}]";

            return str;
        }

    }
}
