namespace TIMSBack.Application.Inventory.ProductsAndServices.Queries
{
    public class ProductsAndServicesDto
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double GrossWeight { get; set; }
        public string SKU { get; set; }
        public double Barcode { get; set; }
        public int MPE { get; set; }
        public string Photo { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public string Trademark { get; set; }
        public int OnHand { get; set; }
        public double Price { get; set; }
        public int TrademarkId { get; internal set; }
        public int CategoryId { get; set; }

        public int ReservedQuantity { get; set; }
        public int CommitedQuantity { get; set; }
        public int AwaitingQuantity { get; set; }

        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public int? DocumentId { get; set; }

    }
}

