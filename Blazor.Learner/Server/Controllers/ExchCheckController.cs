using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GridMvc.Server;
using GridShared;

using BlazorCookies.Models;
using BlazorCookies.DAL;
using BlazorCookies.Server.Data;
using BlazorCookies.Shared;

namespace BlazorCookies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchCheckController : Controller
    {
        public IControllerExt cntExt;
        private EUnitOfWork unitOfWork;
        protected ApplicationDBContext model;
        private DBTable<EXCHCHECK> exchcheck;
        private readonly ILogger<CounterpartyController> logger;
        public IConfiguration Configuration { get; }
        public ExchCheckController( EUnitOfWork unitOfWork, ApplicationDBContext _model, ILogger<CounterpartyController> logger, IConfiguration configuration)
        {
            
            this.unitOfWork = unitOfWork;
            model = _model;           
            exchcheck = unitOfWork.TblExchcheck;
            this.logger = logger;
            Configuration = configuration;
        }

        [HttpGet("[action]")]
        public ActionResult GetExchCheck()
        {
           
            IGridServer<EXCHCHECK> server = new GridServer<EXCHCHECK>(exchcheck.Get(), Request.Query,
                true, "ordersGrid", ColumnCollections.ExchcheckColumns)
                    .WithPaging(10)
                    .Sortable()
                    .Filterable()
                    .WithMultipleFilters()
                    .WithGridItemsCount();

            var items = server.ItemsToDisplay;
            return Ok(items);
        }
    }
}
