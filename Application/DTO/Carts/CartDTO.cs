using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Carts
{
    public class CartDTO
    {
        public string User { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
