using System;
using System.Collections.Generic;
using System.Text;
using TIMSBack.Domain.Common;

namespace TIMSBack.Domain.Entities
{
    public class ProductList : AuditableEntity
    {
        public ProductList()
        {
            Items = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public IList<Product> Items { get; set; }
    }
}
