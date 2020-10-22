using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Categories.Queries;
using TIMSBack.Domain.Entities;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesListsController : ApiController
    {
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await Mediator.Send(new GetCategoriesQuery());
        }
    }
}
