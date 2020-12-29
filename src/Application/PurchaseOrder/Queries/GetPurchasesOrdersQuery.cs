using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.SalesOrder.Queries;

namespace TIMSBack.Application.PurchaseOrder.Queries
{
    public class GetPurchasesOrdersQuery : IRequest<List<PurchasesOrderListDto>>
    {
    }

    public class GetPurchasesOrdersQueryHandler : IRequestHandler<GetPurchasesOrdersQuery, List<PurchasesOrderListDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPurchasesOrdersQueryHandler(IApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<PurchasesOrderListDto>> Handle(GetPurchasesOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from salesOrders in _context.SalesOrders.ToList()
                join customers in _context.Customers on salesOrders.CustomerId equals customers.Id
                join statuses in _context.Statuses on salesOrders.StatusId equals statuses.Id
                join quantityStatuses in _context.QuantityStatuses on salesOrders.QuantityStatusId equals quantityStatuses.Id
                join shippingStatuses in _context.ShippingStatuses on salesOrders.ShippingStatusId equals shippingStatuses.Id
                join paymentStatuses in _context.PaymentStatuses on salesOrders.PaymentStatusId equals paymentStatuses.Id
                join wareHouses in _context.WareHouses on salesOrders.WareHouseId equals wareHouses.Id

                select new PurchasesOrderListDto
                {
                    Id = salesOrders.Id,
                    Tag = salesOrders.Tag,
                    Date = salesOrders.Date,
                    SupplierId = salesOrders.CustomerId,
                    SupplierName = customers.Name,
                    StatusId = salesOrders.StatusId,
                    StatusName = statuses.Name,
                    QuantityStatusId = salesOrders.QuantityStatusId,
                    QuantityStatusName = quantityStatuses.Name,
                    ShippingStatusId = shippingStatuses.Id,
                    PaymentStatusId = paymentStatuses.Id,
                    PaymentStatusName = paymentStatuses.Name,
                    Amount = salesOrders.Amount,
                    AmountTaxIncl = salesOrders.AmountTaxIncl,
                    UnpaidAmount = salesOrders.UnpaidAmount,
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


