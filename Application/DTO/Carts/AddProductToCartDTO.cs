using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Carts
{
    public class AddProductToCartDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
