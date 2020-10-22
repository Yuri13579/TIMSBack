using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class Customer:  BaseIdName
    {
        public string Email { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CategoryCustomerId { get; set; }
        public CategoryCustomer CategoryCustomer { get; set; }
        public int PriceTierId { get; set; }
        public PriceTier PriceTier { get; set; }
        public string TaxLocation { get; set; }
        public int TermsOfPaymentId { get; set; }
        public TermsOfPayment TermsOfPayment { get; set; }
        public ICollection<CustomerPaymentHistory> CustomerPaymentHistories { get; set; }

    }
}
