using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities
{
    public class BasePaymentHistory : BaseIdName
    {
        public double TheyOwnYou { get; set; }
        public double YouOwnThem { get; set; }
        public double Balance { get; set; }

    }


}
