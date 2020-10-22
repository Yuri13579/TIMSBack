using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class SalesOrder : BaseId
    {
        public string Tag { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public QuantityStatus QuantityStatus { get; set; }
        public int QuantityStatusId { get; set; }
        public ShippingStatus ShippingStatus { get; set; }
        public int ShippingStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }
        public double? Amount { get; set; }
        public double? AmountTaxIncl { get; set; }
        public double? UnpaidAmount { get; set; }
        public double? AdvancePayment { get; set; }
        public WareHouse WareHouse { get; set; }
        public int WareHouseId { get; set; }
        public double? Cash { get; set; }
        public double? CreditCard { get; set; }
    }
}
