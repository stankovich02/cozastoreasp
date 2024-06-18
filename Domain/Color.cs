using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Color : NamedEntity
    {
        public virtual ICollection<ProductColor> Products { get; set; } = new HashSet<ProductColor>();
    }
}
