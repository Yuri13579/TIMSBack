using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class CustomerPaymentHistory : BaseIdName
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double TheyOwnYou { get; set; }
        public double YouOwnThem { get; set; }
        public double Balance { get; set; }

    }
}
