using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Products.Commands.CreateProduct;
using TIMSBack.Application.Products.Commands.DeleteProduct;
using TIMSBack.Application.Products.Commands.UpdateProduct;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdateProductDetailCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

    }
}
