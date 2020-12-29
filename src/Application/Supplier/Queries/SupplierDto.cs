using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Supplier.Queries
{
    public class SupplierDto : BaseIdName
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CategorySupplierId { get; set; }
        public string CategorySupplier { get; set; }
        public string TaxLocation { get; set; }
        public int TermsOfPaymentId { get; set; }
        public string TermsOfPayment { get; set; }
        public double TheyOwnYou { get; set; }
        public double YouOwnThem { get; set; }
        public double Balance { get; set; }
    }
}
