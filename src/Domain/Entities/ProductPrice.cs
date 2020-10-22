using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductPrice : AuditableEntity
    {
        public int ProductPriceId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double PriceTaxExcluded { get; set; }
    }
}
