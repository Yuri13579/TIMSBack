using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TIMSBack.Domain.Entities.Inventory
{
    public class Transfer : BaseIdName
    {
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int QuantityStatusId { get; set; }
        public QuantityStatus QuantityStatus { get; set; }
       
        public int SentQuantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public double StockAmount { get; set; }
        public int SourceWareHouseId { get; set; }
        public virtual WareHouse SourceWareHouse { get; set; }
        public int DestinationWareHouseId { get; set; }
        public virtual WareHouse DestinationWareHouse { get; set; }
    }

}
