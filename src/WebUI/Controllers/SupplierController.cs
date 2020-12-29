using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Customer.Queries;
using TIMSBack.Application.Supplier.Queries;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ApiController
    {
        [HttpGet]
        public async Task<List<SupplierDto>> Get()
        {
            return await Mediator.Send(new GetSuppliersQuery());
        }
    }
}
