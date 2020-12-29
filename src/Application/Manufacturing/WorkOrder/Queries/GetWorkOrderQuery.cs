using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Customer.Queries;

namespace TIMSBack.Application.Manufacturing.WorkOrder.Queries
{
    public class GetWorkOrderQuery : IRequest<List<WorkOrderDto>>
    {
    }

    public class GetWorkOrderQueryHandler : IRequestHandler<GetWorkOrderQuery, List<WorkOrderDto>>
    {
        private readonly IApplicationDbContext _context;


        public GetWorkOrderQueryHandler(IApplicationDbContext context

        )
        {
            _context = context;

        }

        public async Task<List<WorkOrderDto>> Handle(GetWorkOrderQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from workOrders in _context.WorkOrders
                join status in _context.Statuses on workOrders.StatusId equals status.Id
                join quantityStatusNames in _context.QuantityStatuses on workOrders.QuantityStatusId equals quantityStatusNames.Id
                join inputWareHouses in _context.WareHouses on workOrders.InputWareHouseId equals inputWareHouses.Id
                join outputWareHouses in _context.WareHouses on workOrders.OutWareHouseId equals outputWareHouses.Id

                select new WorkOrderDto
                {
                    Id = workOrders.Id,
                    Name = workOrders.Name,
                    StatusName = status.Name,
                    QuantityStatusName = quantityStatusNames.Name,
                    Date = workOrders.Date,
                    EstimatedCost = workOrders.EstimatedCost,
                    FinishedGood = workOrders.FinishedGood,
                    InputWareHouseName = inputWareHouses.Name,
                    OutWareHouseName = outputWareHouses.Name

                }).ToList();

         return await Task.FromResult(result);
        }
        
    }

}
