using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Inventory.Transfer.Queries;
using TIMSBack.Application.Manufacturing.WorkOrder.Queries;

namespace TIMSBack.WebUI.Controllers.Inventory
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ApiController
    {
        [HttpGet]
        public async Task<List<TransferDto>> Get()
        {
            return await Mediator.Send(new GetTransferQuery());
        }
    }
}
