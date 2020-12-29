using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Customer.Queries;
using TIMSBack.Application.Manufacturing.WorkOrder.Queries;

namespace TIMSBack.WebUI.Controllers.Manufacturing
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ApiController
    {
        [HttpGet]
        public async Task<List<WorkOrderDto>> Get()
        {
            return await Mediator.Send(new GetWorkOrderQuery());
        }
    }

}
