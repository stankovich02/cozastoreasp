﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
