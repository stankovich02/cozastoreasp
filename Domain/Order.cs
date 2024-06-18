using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime OrderedAt { get; set; }   

        public virtual User User { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
