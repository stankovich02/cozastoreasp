using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductImage
    {
        public int ProductId { get; set; }
        public int ImageId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}
