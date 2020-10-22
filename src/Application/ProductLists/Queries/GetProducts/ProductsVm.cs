using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Application.TodoLists.Queries.GetTodos;

namespace TIMSBack.Application.ProductLists.Queries.GetProducts
{
    public class ProductsVm
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<ProductListDto> Lists { get; set; }
    }
}
