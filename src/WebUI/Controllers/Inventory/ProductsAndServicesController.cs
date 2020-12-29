using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Inventory.ProductsAndServices.Queries;

namespace TIMSBack.WebUI.Controllers.Inventory
{
    //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAndServicesController : ApiController
    {
        [HttpGet]
        public async Task<List<ProductsAndServicesDto>> Get()
        {
            return await Mediator.Send(new GetProductsAndServicesQuery());
        }
        

    }
}
