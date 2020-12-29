using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities.Manufacturing
{
    public class WorkOrder : BaseIdName
    {
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int QuantityStatusId { get; set; }
        public QuantityStatus QuantityStatus { get; set; }
        public int MaterialLoading { get; set; }
        public int FinishedGood { get; set; }
        public double EstimatedCost { get; set; }

        public int InputWareHouseId { get; set; }
        public WareHouse InputWareHouse { get; set; }
        public int OutWareHouseId { get; set; }
        public WareHouse OutWareHouse { get; set; }
    }
}
