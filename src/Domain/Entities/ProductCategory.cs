using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
