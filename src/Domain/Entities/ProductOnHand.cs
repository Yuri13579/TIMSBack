using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductOnHand : AuditableEntity
    {
        public int ProductOnHandId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OnHandCount { get; set; }
    }
}
