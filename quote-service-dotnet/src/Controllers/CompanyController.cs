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


namespace WebApi.CompanyController
{
    [Route("v1/companies")]
    [ApiController]
    public class CompanyController : ControllerBase

    {
        [HttpGet("{query}")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<CompanyInfo>> getCompany(string query)
        {

            return  QuoteService.GetCompanyInfo(query).GetAwaiter().GetResult();


        }

    }

}
