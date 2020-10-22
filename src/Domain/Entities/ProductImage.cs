using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductImage : AuditableEntity
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageText { get; set; }
    }
}
