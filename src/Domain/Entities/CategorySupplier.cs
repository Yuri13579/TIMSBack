using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class CategorySupplier : BaseIdName
    {
        public ICollection<Supplier> Suppliers { get; set; }
    }

}
