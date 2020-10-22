using System.Collections.Generic;
using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProductUnitId { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public ProductImage ProductImage { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductTrademark> ProductTrademarks { get; set; }
        public ProductOnHand ProductOnHand { get; set; }
        public ProductPrice ProductPrice { get; set; }
    }

}
