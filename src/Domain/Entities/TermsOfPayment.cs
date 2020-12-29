using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class TermsOfPayment: BaseIdName
    {
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
