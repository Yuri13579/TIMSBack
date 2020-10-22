using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Application.SalesOrder.Queries
{
    public class SalesOrderListDto
    {
        public int Id { get; set; }
        public string Tag { get; internal set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; internal set; }
        public string CustomerName { get; internal set; }
        public int StatusId { get; internal set; }
        public string StatusName { get; internal set; }
        public int QuantityStatusId { get; set; }
        public string QuantityStatusName { get; set; }
        public int ShippingStatusId { get; internal set; }
        public string PaymentStatusName { get; internal set; }
        public int PaymentStatusId { get; internal set; }
        public double? Amount { get; internal set; }
        public double? AmountTaxIncl { get; set; }
        public double? UnpaidAmount { get; internal set; }
        public double? AdvancePayment { get; internal set; }
        public int WareHouseId { get; internal set; }
        public string WareHouseName { get; internal set; }
        public double? Cash { get; set; }
        public double? CreditCard { get; set; }
    }
}
