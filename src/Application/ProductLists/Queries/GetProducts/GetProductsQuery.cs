using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.TodoLists.Queries.GetTodos;
using TIMSBack.Domain.Enums;

namespace TIMSBack.Application.ProductLists.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductListDto>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductListDto>>
    {
        private readonly IApplicationDbContext _context;
       // private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context
            //, IMapper mapper
            )
        {
            _context = context;
           // _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productsList =  (
                from products in _context.Products.ToList()
                join descriptions in _context.ProductDescriptions
                    on products.ProductId equals descriptions.ProductId
                join productImage in _context.ProductImages
                    on products.ProductId equals productImage.ProductId
                join productCategories in _context.ProductCategorys.ToList()
                    on products.ProductId equals productCategories.ProductId
                join categories in _context.Categories.ToList()
                    on productCategories.CategoryId equals categories.CategoryId
                join productOnHands in _context.ProductOnHands.ToList()
                    on products.ProductId equals productOnHands.ProductId
                join productPrices in _context.ProductPrices.ToList()
                    on products.ProductId equals productPrices.ProductId
                join productTrademarks in _context.ProductTrademarks.ToList()
                    on products.ProductId equals productTrademarks.ProductId
                join trademarks in _context.Trademarks.ToList()
                    on productTrademarks.TrademarkId equals trademarks.TrademarkId
                join productUnits in _context.ProductUnits.ToList()
                    on products.ProductUnitId equals productUnits.ProductUnitId
                select new ProductListDto
                {
                    ProductId = products.ProductId,
                    ProductName = products.Name,
                    Barcode = descriptions.Barcode,
                    Category = categories.CategoryName,
                    GrossWeight = descriptions.GrossWeight,
                    MPE = descriptions.MPE,
                    OnHand = productOnHands.OnHandCount,
                    Photo = productImage.ImageText,
                    Price = Math.Round(
                        productPrices.PriceTaxExcluded * ((Convert.ToDouble(descriptions.MPE) / 100) + 1), 2),
                    SKU = descriptions.SKU,
                    Trademark = trademarks.TrademarkName,
                    Unit = productUnits.UnitName

                }).ToList();
            
            return productsList;
        }
    }
}
