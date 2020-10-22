using System.Collections.Generic;
using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
