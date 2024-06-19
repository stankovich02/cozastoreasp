using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Orders
{
    public class CreateOrderDTO
    {
        public int PaymentTypeId { get; set; }
        public IEnumerable<ProductCartDTO> Products { get; set; }
    }
    public class ProductCartDTO
    {
       public int ProductId { get; set; }
       public int Quantity { get; set; }
    }
    public class ProductWithCurrentPriceDTO
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
