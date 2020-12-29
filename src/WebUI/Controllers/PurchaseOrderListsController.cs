using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.PurchaseOrder.Queries;
using TIMSBack.Application.SalesOrder.Queries;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderListsController : ApiController
    {
        [HttpGet]
        public async Task<List<PurchasesOrderListDto>> Get()
        {
            return await Mediator.Send(new GetPurchasesOrdersQuery());
        }
    }

}