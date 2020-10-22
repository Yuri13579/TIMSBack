using System.Collections.Generic;
using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductUnit : AuditableEntity
    {
        public int ProductUnitId { get; set; }
        public string UnitName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
