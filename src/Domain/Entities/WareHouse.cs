using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Entities.Inventory;

namespace TIMSBack.Domain.Entities
{
    public class WareHouse : BaseIdName
    {
        public virtual ICollection<Transfer> SourceWareHouses { get; set; }
        public virtual ICollection<Transfer> DestinationWareHouses { get; set; }
 
    }
}
