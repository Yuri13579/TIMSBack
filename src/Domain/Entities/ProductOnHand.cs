using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductOnHand : AuditableEntity
    {
        public int ProductOnHandId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OnHandCount { get; set; }

        public int ReservedQuantity { get; set; }
        public int CommitedQuantity { get; set; }
        public int AwaitingQuantity { get; set; }

        public int WareHouseId { get; set; }
        public int? DocumentId { get; set; }

    }
}
