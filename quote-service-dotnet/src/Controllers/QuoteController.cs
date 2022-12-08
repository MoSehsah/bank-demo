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


namespace WebApi.QuotesController
{
    [Route("v1")]
    [ApiController]
    public class quotesController : ControllerBase

    {
        // GET v1/quotes?q=vmw
        [HttpGet("{quote}")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Quote>> getQuote(string quote)
        {
            IexQuote iexQuote =  QuoteService.GetIexQuoteAsync(quote).GetAwaiter().GetResult();
            Quote quoteObj = QuoteMapper.INSTANCE.mapFromIexQuote(iexQuote);
            List<Quote> quotes = new List<Quote>();
            quotes.Add(quoteObj);
            return quotes;
        }

    }

}
