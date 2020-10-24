﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.SalesOrder.Queries;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderListsController : ApiController
    {
        [HttpGet]
        public async Task<List<SalesOrderListDto>> Get()
        {
            return await Mediator.Send(new GetSalesOrdersQuery());
        }
    }

}