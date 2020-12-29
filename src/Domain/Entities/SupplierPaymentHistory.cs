using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class SupplierPaymentHistory : BasePaymentHistory
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }


}
