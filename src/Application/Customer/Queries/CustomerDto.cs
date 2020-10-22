using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Customer.Queries
{
    public class CustomerDto: BaseIdName 
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CategoryCustomerId { get; set; }
        public string CategoryCustomer { get; set; }
        public int PriceTierId { get; set; }
        public string PriceTier { get; set; }
        public string TaxLocation { get; set; }
        public int TermsOfPaymentId { get; set; }
        public string TermsOfPayment { get; set; }
        public double TheyOwnYou { get; set; }
        public double YouOwnThem { get; set; }
        public double Balance { get; set; }
    }
}
