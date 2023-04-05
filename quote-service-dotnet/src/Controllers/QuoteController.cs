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
using System.Collections.Generic;
using System.Collections;


namespace WebApi.QuoteController
{
    [Route("v1/quotes")]
    [ApiController]
    public class QuoteController : ControllerBase

    {
        // GET v1/quotes?q=vmw
        [HttpGet()]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Quote>> getQuote(string q)
        {
            List<Quote> quotes;
            string[] splitQuery = q.Split(',');
            if (splitQuery.Length > 1)
            {
                quotes = QuoteService.GetIexQuotesAsync(q).GetAwaiter().GetResult();
            }
            else
            {
                Quote iexQuote = QuoteService.GetIexQuoteAsync(splitQuery[0]).GetAwaiter().GetResult();
                
                quotes = new List<Quote>();
                quotes.Add(iexQuote);
            }

            return quotes;
        }

    }

}
