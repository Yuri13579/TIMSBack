using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductDescription : AuditableEntity
    {
        public int ProductDescriptionId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double GrossWeight { get; set; }
        public ulong Barcode { get; set; }
        public int MPE { get; set; }
        public string SKU { get; set; }

    }
}
