using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public virtual ICollection<ProductImage> Products { get; set; } = new HashSet<ProductImage>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
