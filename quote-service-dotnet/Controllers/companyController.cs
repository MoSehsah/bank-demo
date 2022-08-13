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

namespace WebApi.CompanyController
{
    [Route("v1/company")]
    [ApiController]
    public class companyController : ControllerBase

    {
        // GET api/values/5
        private static HttpClient Client = new HttpClient();
        [HttpGet("{company}")]
        [Produces("application/json")]
        public ActionResult<JArray> Details(string q)
        {
            var iexUrl = $"https://sandbox.iexapis.com/stable/stock/{q}/quote?token=Tpk_c05ba4ad3b434f7ab8ffa87cfaab503a";
            var result = Client.GetAsync(iexUrl);
            var iexResult = result.Result.Content.ReadAsStringAsync().Result;
            JObject jo = JObject.Parse(iexResult);
            jo.Add("Symbol",jo.Property("symbol").Value);
            jo.Property("symbol").Remove();
            jo.Add("Name",jo.Property("companyName").Value);
            jo.Property("companyName").Remove();
            jo.Add("Exchange","NASDAQ");



            jo.Property("latestPrice").Remove();

            jo.Property("change").Remove();

            jo.Property("changePercent").Remove();

            jo.Property("marketCap").Remove();

            jo.Property("volume").Remove();
            jo.Property("high").Remove();
            jo.Property("low").Remove();
            jo.Property("open").Remove();
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
            JArray jsonArray = JArray.Parse(str);
            return jsonArray;
        }

    }
}
