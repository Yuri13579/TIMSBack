using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;

namespace TIMSBack.Application.Inventory.ProductsAndServices.Queries
{
    public class GetProductsAndServicesQuery : IRequest<List<ProductsAndServicesDto>>
    {
    }

    public class GetProductsAndServicesQueryHandler : IRequestHandler<GetProductsAndServicesQuery, List<ProductsAndServicesDto>>
    {
        private readonly IApplicationDbContext _context;
        // private readonly IMapper _mapper;

        public GetProductsAndServicesQueryHandler(IApplicationDbContext context
            //, IMapper mapper
            )
        {
            _context = context;
            // _mapper = mapper;
        }

        public async Task<List<ProductsAndServicesDto>> Handle(GetProductsAndServicesQuery request, CancellationToken cancellationToken)
        {
            var productsList = (
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
                join wareHouse in _context.WareHouses on productOnHands.WareHouseId equals wareHouse.Id 
                select new ProductsAndServicesDto
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
                    ReservedQuantity = productOnHands.ReservedQuantity,
                    CommitedQuantity = productOnHands.CommitedQuantity,
                    AwaitingQuantity = productOnHands.AwaitingQuantity,
                    WareHouseId  = productOnHands.WareHouseId,
                    WareHouseName = wareHouse.Name

                }).ToList();

            return productsList;
        }
        
    }
}
