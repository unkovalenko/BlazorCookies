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
using Newtonsoft.Json;
using GridMvc.Server;
using GridShared;






namespace BlazorCookies.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterpartyController : Controller
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

        //[HttpGet]
        //public CounterpartyData[] Get()
        //{
        //    string jsonString = (CounterpartyReuest("").Result.ToString());
        //    CounterpartyList counterpartyList = JsonConvert.DeserializeObject<CounterpartyList>(jsonString);
        //    List<CounterpartyData> templist = counterpartyList.data.ToList<CounterpartyData>().OrderBy(o => o.FirstName).ToList();
        //    return templist.ToArray();
        //}

        [HttpGet("[action]")]
        public ActionResult get()
        {
            string jsonString = (CounterpartyReuest("").Result.ToString());
            CounterpartyList counterpartyList = JsonConvert.DeserializeObject<CounterpartyList>(jsonString);
            List<CounterpartyData> templist = counterpartyList.data.ToList<CounterpartyData>().ToList();
            Action<IGridColumnCollection<CounterpartyData>> Columns = c =>
            {
                c.Add(o => o.Description)
                .Titled("Описание")
                    .Sortable(true)
                    .Filterable(true)
                    .SetWidth(220);
                c.Add(o => o.EDRPOU);
                c.Add(o => o.Counterparty);
                c.Add(o => o.Ref);
            };

            IGridServer<CounterpartyData> server = new GridServer<CounterpartyData>((IEnumerable<CounterpartyData>)templist, Request.Query,
                true, "ordersGrid", Columns).WithPaging(10)
                    .Sortable()
                    .Filterable()
                    .WithMultipleFilters()
                    .WithGridItemsCount()
                    .Searchable(true, false, false);
            var items = server.ItemsToDisplay;
            return Ok(items);
        }




        [HttpGet("{searchString}")]
        public CounterpartyData[] Get(string searchString)
        {
            string jsonString = (CounterpartyReuest(searchString).Result.ToString());
            CounterpartyList counterpartyList = JsonConvert.DeserializeObject<CounterpartyList>(jsonString);
            List<CounterpartyData> templist = counterpartyList.data.ToList<CounterpartyData>().OrderBy(o => o.FirstName).ToList();
            return templist.ToArray();
        }

        public async Task<string> CounterpartyReuest(string searchstring)
        {
            var client = clientFactory.CreateClient("NewPostAPI");
            CountepartyListReqwest reuest = new CountepartyListReqwest(Configuration,searchstring);
            var jrequest = new StringContent(System.Text.Json.JsonSerializer.Serialize(reuest));
            using var httpResponse = await client.PostAsync(new Uri(Configuration.GetValue<string>("URLNewPos")), jrequest);
            return httpResponse.Content.ReadAsStringAsync().Result;
        }
    }

}

