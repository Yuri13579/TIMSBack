using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class Customer : Contractor
    {
        public ICollection<CustomerPaymentHistory> CustomerPaymentHistories { get; set; }
        public int CategoryCustomerId { get; set; }
        public CategoryCustomer CategoryCustomer { get; set; }
        public int PriceTierId { get; set; }
        public PriceTier PriceTier { get; set; }
    }
}
