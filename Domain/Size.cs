using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Size : NamedEntity
    {
        public virtual ICollection<ProductSize> Products { get; set; } = new HashSet<ProductSize>();
    }
}
