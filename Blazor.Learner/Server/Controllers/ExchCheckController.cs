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
                    .WithGridItemsCount()
                    ;

            var items = server.ItemsToDisplay;
            return Ok(items);
        }


        [HttpGet]
        public ActionResult GetAllExchcheck()
        {

            var _exchcheck = exchcheck.Get();
            if (_exchcheck == null)
            {
                return NotFound();
            }
            return Ok(_exchcheck);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EXCHCHECK _exchcheck)
        {
            if (ModelState.IsValid)
            {
                if (_exchcheck == null)
                {
                    return BadRequest();
                }

                //var repository = new OrdersRepository(_context);
                try
                {
                  await exchcheck.InsertAsync(_exchcheck);
                    // await repository.Insert(_exchcheck);
                    exchcheck.Save();

                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest(new
                    {
                        message = e.Message.Replace('{', '(').Replace('}', ')')
                    });
                }
            }
            return BadRequest(new
            {
                message = "ModelState is not valid"
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExchcheck(int id)
        {

            EXCHCHECK ex = await exchcheck.GetByIDAsync(id);
            if (ex == null)
            {
                return NotFound();
            }
            return Ok(ex);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExchcheck(int id, [FromBody] EXCHCHECK ex)
        {
            if (ModelState.IsValid)
            {
                if (ex == null || ex.EC_ID != id)
                {
                    return BadRequest();
                }

               
                try
                {
                    await exchcheck.UpdateAsync(ex);
                    exchcheck.Save();

                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest(new
                    {
                        message = e.Message.Replace('{', '(').Replace('}', ')')
                    });
                }
            }
            return BadRequest(new
            {
                message = "ModelState is not valid"
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            EXCHCHECK ex = await exchcheck.GetByIDAsync(id);

            if (ex == null)
            {
                return NotFound();
            }

            try
            {
                exchcheck.Delete(ex);
                exchcheck.Save();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message.Replace('{', '(').Replace('}', ')')
                });
            }
        }
    }
}
