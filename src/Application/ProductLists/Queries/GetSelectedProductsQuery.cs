using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.ProductLists.Queries.GetProducts;

namespace TIMSBack.Application.ProductLists.Queries
{
    public class GetSelectedProductsQuery : IRequest<PaginationProductListDto>
    {
        public int PageNumber { get; set;} 
        public int PageSize { get; set; }
        public int[] SelectedTrademarks { get; set; }
        public int[] SelectedCategories { get; set; }
       
    }

    public class GetSelectedProductsQueryHandler : IRequestHandler<GetSelectedProductsQuery, PaginationProductListDto>
    {
        private readonly IApplicationDbContext _context;
 

        public GetSelectedProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<PaginationProductListDto> Handle(GetSelectedProductsQuery request, CancellationToken cancellationToken)
        {
            List<ProductListDto> allProductsList = GetAllProducts();

            if(request.SelectedTrademarks != null && request.SelectedTrademarks.Length> 0)
                allProductsList = allProductsList.Where(x => request.SelectedTrademarks.Contains(x.TrademarkId)).ToList();

            if (request.SelectedCategories != null && request.SelectedCategories.Length > 0)
                allProductsList = allProductsList.Where(x => request.SelectedCategories.Contains(x.CategoryId)).ToList();



            int pageCount = (int) Math.Ceiling((double) allProductsList.Count / (double) request.PageSize);

            List<ProductListDto> productsList;
            if (allProductsList.Count> request.PageSize)
            {
                 productsList = allProductsList.Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize).ToList();
            }
            else
            {
                productsList = allProductsList;
            }
                



            return new PaginationProductListDto
            {
                Products = productsList,
                PageCount = pageCount
            };
        }

        private List<ProductListDto> GetAllProducts()
        {
           var result = (
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
                    Unit = productUnits.UnitName,
                    TrademarkId = trademarks.TrademarkId,
                    CategoryId = categories.CategoryId
                }).ToList();
            
            return result;
        }
    }

}
