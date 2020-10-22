using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class CategoryCustomer : BaseIdName
    {
        public ICollection<Customer> Customers { get; set; }
    }
}
