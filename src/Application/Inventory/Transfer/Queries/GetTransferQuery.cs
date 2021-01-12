using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Manufacturing.WorkOrder.Queries;

namespace TIMSBack.Application.Inventory.Transfer.Queries
{
    public class GetTransferQuery : IRequest<List<TransferDto>>
    {
    }

    public class GetTransferQueryHandler : IRequestHandler<GetTransferQuery, List<TransferDto>>
    {
        private readonly IApplicationDbContext _context;


        public GetTransferQueryHandler(IApplicationDbContext context

        )
        {
            _context = context;

        }

        public async Task<List<TransferDto>> Handle(GetTransferQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from transfers in _context.Transfers
                join status in _context.Statuses on transfers.StatusId equals status.Id
                join quantityStatusNames in _context.QuantityStatuses on transfers.QuantityStatusId equals quantityStatusNames.Id
                //join sourceWareHouses in _context.WareHouses on transfers.SourceWareHouseId equals sourceWareHouses.Id
                //join destinationWareHouses in _context.WareHouses on transfers.DestinationWareHouseId equals destinationWareHouses.Id

                select new TransferDto
                {
                    Id = transfers.Id,
                    Name = transfers.Name,
                    StatusName = status.Name,
                    QuantityStatusName = quantityStatusNames.Name,
                    Date = transfers.DateTime.ToString("dd'/'MM'/'yyyy"),
                    StockAmount = transfers.StockAmount,
                    SentQuantity = transfers.SentQuantity,
                  //  SourceWareHouseName = sourceWareHouses.Name,
                  //  DestinationWareHouseName = destinationWareHouses.Name,
                    ReceivedQuantity = transfers.ReceivedQuantity

                }).ToList();

            return await Task.FromResult(result);
        }

    }
}
