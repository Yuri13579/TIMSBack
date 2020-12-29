using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Application.Manufacturing.WorkOrder.Queries
{
    public class WorkOrderDto : Domain.Entities.Manufacturing.WorkOrder
    {
        public string StatusName { get; set; }
        public string QuantityStatusName { get; set; }
        public string InputWareHouseName { get; set; }
        public string OutWareHouseName { get; set; }
    }
}
