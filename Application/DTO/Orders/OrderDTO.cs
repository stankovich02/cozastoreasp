using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }
        public DateTime OrderedAt { get; set; }
        public IEnumerable<OrderItemDTO> Items { get; set; }
    }
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
