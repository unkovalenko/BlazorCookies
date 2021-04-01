//ContactPersonCounterpartyController
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
    public class ContactPersonCounterpartyController : ControllerBase
    {

        private readonly ILogger<ContactPersonCounterpartyController> logger;
        private readonly IHttpClientFactory clientFactory;
        public IConfiguration Configuration { get; }
        public ContactPersonCounterpartyController(ILogger<ContactPersonCounterpartyController> logger, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
            Configuration = configuration;
        }

        [HttpGet]
        public ContactPersonCounterpartyData[] Get()
        {
            string jsonString = (this.CounterpartyReuest("").Result.ToString());
            ContactPersonCounterparty counterpartyPers = JsonSerializer.Deserialize<ContactPersonCounterparty>(jsonString);
            if (counterpartyPers.success)
            {
                return counterpartyPers.data;
            }
            else
            {
                counterpartyPers.data[0] = new ContactPersonCounterpartyData();
                return counterpartyPers.data;
            }
        }

        [HttpGet("{searchString}")]
        public ContactPersonCounterpartyData[] Get(string searchString)
        {
            string jsonString = (this.CounterpartyReuest(searchString).Result.ToString());
            ContactPersonCounterparty counterpartyPers = JsonSerializer.Deserialize<ContactPersonCounterparty>(jsonString);

            if (counterpartyPers.success)
            {
                return counterpartyPers.data;
            }
            else
            {
                counterpartyPers.data[0] = new ContactPersonCounterpartyData();
                return counterpartyPers.data;
            }
        }

        public async Task<string> CounterpartyReuest(string searchstring)
        {
            var client = clientFactory.CreateClient("NewPostAPI");
            ContactPersonRequest reuest = new ContactPersonRequest(Configuration, searchstring);
            var jrequest = new StringContent(JsonSerializer.Serialize(reuest));
            using var httpResponse = await client.PostAsync(new Uri(Configuration.GetValue<string>("URLNewPos")), jrequest);
            return httpResponse.Content.ReadAsStringAsync().Result;
        }

    }
}
