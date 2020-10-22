using System.Collections.Generic;
using TIMSBack.Application.Common.Mappings;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.ProductLists.Queries.GetProducts
{
    public class ProductListDto : IMapFrom<ProductList>
    {
        public ProductListDto()
        {
            Items = new List<Product>();
        }

  

        public string Name { get; set; }

        public IList<Product> Items { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double GrossWeight { get; set; }
        public string SKU { get; set; }
        public double Barcode { get; set; }
        public int MPE { get; set; }
        public string Photo { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public string Trademark { get; set; }
        public int OnHand { get; set; }
        public double Price { get; set; }
        public int TrademarkId { get; internal set; }
        public int CategoryId { get; set; }
    }

    public class PaginationProductListDto
    {
        public IList<ProductListDto> Products { get; set; }
        public int PageCount { get; set; }

    }
}
