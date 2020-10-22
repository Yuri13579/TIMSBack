using System.Collections.Generic;
using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class Trademark : AuditableEntity
    {
        public int TrademarkId { get; set; }
        public string TrademarkName { get; set; }
        public ICollection<ProductTrademark> ProductTrademarks { get; set; }
    }
}
