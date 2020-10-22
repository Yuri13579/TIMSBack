using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductTrademark : AuditableEntity
    {
        public int ProductTrademarkId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TrademarkId { get; set; }
        public Trademark Trademark { get; set; }
    }
}
