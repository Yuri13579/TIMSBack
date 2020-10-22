using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.ProductLists.Queries.GetProducts;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.SalesOrder.Queries
{
    public class GetSalesOrdersQuery : IRequest<List<SalesOrderListDto>>
    {
    }

    public class GetSalesOrdersQueryHandler : IRequestHandler<GetSalesOrdersQuery, List<SalesOrderListDto>>
    {
        private readonly IApplicationDbContext _context;
      
        public GetSalesOrdersQueryHandler(IApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<SalesOrderListDto>> Handle(GetSalesOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from salesOrders in _context.SalesOrders.ToList()
                join customers in _context.Customers on salesOrders.CustomerId equals customers.Id
                join statuses in _context.Statuses on salesOrders.StatusId equals statuses.Id
                join quantityStatuses in _context.QuantityStatuses on salesOrders.QuantityStatusId equals quantityStatuses.Id
                join shippingStatuses in _context.ShippingStatuses on salesOrders.ShippingStatusId equals shippingStatuses.Id
                join paymentStatuses in _context.PaymentStatuses on salesOrders.PaymentStatusId equals paymentStatuses.Id
                join wareHouses in _context.WareHouses on salesOrders.WareHouseId equals wareHouses.Id

                select new SalesOrderListDto
                {
                    Id = salesOrders.Id,
                    Tag = salesOrders.Tag,
                    Date = salesOrders.Date,
                    CustomerId = salesOrders.CustomerId,
                    CustomerName = customers.Name,
                    StatusId = salesOrders.StatusId,
                    StatusName = statuses.Name,
                    QuantityStatusId = salesOrders.QuantityStatusId,
                    QuantityStatusName = quantityStatuses.Name,
                    ShippingStatusId = shippingStatuses.Id,
                    PaymentStatusId = paymentStatuses.Id,
                    PaymentStatusName = paymentStatuses.Name,
                    Amount = salesOrders.Amount,
                    AmountTaxIncl = salesOrders.AmountTaxIncl,
                    UnpaidAmount = salesOrders.UnpaidAmount ,
                    AdvancePayment = salesOrders.AdvancePayment,
                    WareHouseId = wareHouses.Id,
                    WareHouseName = wareHouses.Name,
                    Cash = salesOrders.Cash,
                    CreditCard = salesOrders.CreditCard 

                }).ToList();

            return result;
        }
    }
}
