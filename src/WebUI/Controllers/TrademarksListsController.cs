using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.ProductLists.Queries;
using TIMSBack.Application.ProductLists.Queries.GetProducts;
using TIMSBack.Application.Trademarks.Queries.GetTrademarks;
using TIMSBack.Domain.Entities;

namespace TIMSBack.WebUI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrademarksListsController : ApiController
    {
        [HttpGet]
        public async Task<List<Trademark>> Get()
        {
            return await Mediator.Send(new GetTrademarksQuery());
        }
    }
}
