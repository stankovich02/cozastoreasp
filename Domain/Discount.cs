using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Discount : Entity
    {
        public int ProductId { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public virtual Product Product { get; set; }
    }
}
