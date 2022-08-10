using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            return iexResult;
        }

    }
}
