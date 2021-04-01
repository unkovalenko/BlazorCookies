using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazorCookies.Shared.Models;

namespace BlazorCookies.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CounterpartyAdresController : ControllerBase
    {

        private readonly ILogger<CounterpartyAdresController> logger;
        private readonly IHttpClientFactory clientFactory;
        public IConfiguration Configuration { get; }
        public CounterpartyAdresController(ILogger<CounterpartyAdresController> logger, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
            Configuration = configuration;
        }

        [HttpGet]
        public CounterpartyAdresData[] Get()
        {
            string jsonString = (this.CounterpartyReuest("").Result.ToString());
            CounterpartyAdres counterpartyAdres = JsonSerializer.Deserialize<CounterpartyAdres>(jsonString);
            if (counterpartyAdres.success)
            {
                return counterpartyAdres.data;
            }
            else
            {
                counterpartyAdres.data[0] = new CounterpartyAdresData();
                return counterpartyAdres.data;
            }
        }

        [HttpGet("{searchString}")]
        public CounterpartyAdresData[] Get(string searchString)
        {
            string jsonString = (this.CounterpartyReuest(searchString).Result.ToString());
            CounterpartyAdres counterpartyAdres = JsonSerializer.Deserialize<CounterpartyAdres>(jsonString);
            if (counterpartyAdres.success)
            {
                return counterpartyAdres.data;
            }
            else 
            {
                counterpartyAdres.data[0] = new CounterpartyAdresData();
                return counterpartyAdres.data;
            }
        }

        public async Task<string> CounterpartyReuest(string searchstring)
        {
            var client = clientFactory.CreateClient("NewPostAPI");
            CounterpartyAdresRequest reuest = new CounterpartyAdresRequest(Configuration, searchstring);
            var jrequest = new StringContent(JsonSerializer.Serialize(reuest));
            using var httpResponse = await client.PostAsync(new Uri(Configuration.GetValue<string>("URLNewPos")), jrequest);
            return httpResponse.Content.ReadAsStringAsync().Result;
        }

    }
}
