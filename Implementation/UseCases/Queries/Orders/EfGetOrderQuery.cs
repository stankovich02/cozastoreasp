using Application.DTO.Orders;
using Application.UseCases.Queries.Orders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Orders
{
    public class EfGetOrderQuery : IGetOrderQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetOrderQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 66;

        public string Name => "Get single Order";

        public OrderDTO Execute(int search)
        {
            return _response.ReturnSingle<Order, OrderDTO>(search, entity => new OrderDTO
            {
                Id = entity.Id,
                OrderedAt = entity.OrderedAt,
                PaymentType = entity.PaymentType.Name,
                TotalPrice = entity.TotalPrice,
                User = entity.User.Username,
                Items = entity.OrderItems.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    Product = item.Product.Name,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            });
        }
    }
}
