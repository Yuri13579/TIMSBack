using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Entities.Inventory;

namespace TIMSBack.Domain.Entities
{
    public class QuantityStatus: BaseIdName
    {
        public ICollection<Transfer> Transfers { get; set; }

    }
}
