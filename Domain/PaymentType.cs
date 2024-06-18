using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PaymentType : NamedEntity
    {
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
