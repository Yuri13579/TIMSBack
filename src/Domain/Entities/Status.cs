using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Entities.Inventory;

namespace TIMSBack.Domain.Entities
{
    public class Status : BaseIdName
    {
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
