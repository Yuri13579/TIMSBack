using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Application.Inventory.Transfer.Queries
{
    public class TransferDto : Domain.Entities.Inventory.Transfer
    {
        public string StatusName { get; set; }
        public string QuantityStatusName { get; set; }
        public string SourceWareHouseName { get; set; }
        public string DestinationWareHouseName { get; set; }
    }
}
