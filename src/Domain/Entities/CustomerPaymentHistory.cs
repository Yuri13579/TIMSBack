using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class CustomerPaymentHistory : BasePaymentHistory
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
     }
}
