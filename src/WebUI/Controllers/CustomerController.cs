using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Categories.Queries;
using TIMSBack.Application.Customer.Queries;
using TIMSBack.Domain.Entities;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:  ApiController
    {
        [HttpGet]
        public async Task<List<CustomerDto>> Get()
        {
            return await Mediator.Send(new GetCustomersQuery());
        }
    }
}
