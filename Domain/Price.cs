using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Price : Entity
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }


        public virtual Product Product { get; set; }
    }
}
