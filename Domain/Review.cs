using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Review : Entity
    {
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }
        public int UserId { get; set; }


        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
