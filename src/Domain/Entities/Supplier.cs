using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class Supplier : Contractor
    {
        public CategorySupplier CategorySupplier { get; set; }
        public int CategorySupplierId { get; set; }
        public IEnumerable<SupplierPaymentHistory> SupplierPaymentHistories { get; set; }
    }
}
