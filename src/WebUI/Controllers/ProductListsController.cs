using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.ProductLists.Queries;
using TIMSBack.Application.ProductLists.Queries.GetProducts;
using TIMSBack.Application.TodoItems.Commands.CreateTodoItem;
using TIMSBack.Application.TodoItems.Commands.DeleteTodoItem;
using TIMSBack.Application.TodoItems.Commands.UpdateTodoItem;
using TIMSBack.Application.TodoItems.Commands.UpdateTodoItemDetail;
using TIMSBack.Application.TodoLists.Queries.ExportTodos;
using TIMSBack.Application.TodoLists.Queries.GetTodos;

namespace TIMSBack.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListsController : ApiController
    {
        [HttpGet]
        public async Task<List<ProductListDto>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpPut]
        public async Task<PaginationProductListDto> GetSelected(GetSelectedProductsQuery command)
        {
            return await Mediator.Send(command);
        }

        //[HttpGet("{id}")]
        //public async Task<FileResult> Get(int id)
        //{
        //    var vm = await Mediator.Send(new ExportProductsQuery { ListId = id });

        //    return File(vm.Content, vm.ContentType, vm.FileName);
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateProductListCommand command)
        //{
        //    return await Mediator.Send(command);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, UpdateProductListCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeleteProductListCommand { Id = id });

        //    return NoContent();
        //}


    }

}
