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
    [ApiController]
    [Route("[controller]")]
    public class CounterpartyController : ControllerBase
    {
        private readonly ILogger<CounterpartyController> logger;
        private readonly IHttpClientFactory clientFactory;
        public IConfiguration Configuration { get; }
        public CounterpartyController(ILogger<CounterpartyController> logger, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
            Configuration = configuration;
        }

        [HttpGet]
        public CounterpartyData[] Get()
        {
            string jsonString = (CounterpartyReuest().Result.ToString());
            CounterpartyList counterpartyList = JsonSerializer.Deserialize<CounterpartyList>(jsonString);
            return counterpartyList.data;
        }

        public async Task<string> CounterpartyReuest()
        {
            var client = clientFactory.CreateClient("NewPostAPI");
            CountepartyListReqwest reuest = new CountepartyListReqwest(Configuration);
            var jrequest = new StringContent(JsonSerializer.Serialize(reuest));
            using var httpResponse = await client.PostAsync(new Uri(Configuration.GetValue<string>("URLNewPos")), jrequest);
            return httpResponse.Content.ReadAsStringAsync().Result;
        }
    }

}

