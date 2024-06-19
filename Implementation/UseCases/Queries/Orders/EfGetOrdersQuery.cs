using Application.DTO;
using Application.DTO.Orders;
using Application.DTO.Sizes;
using Application.UseCases.Queries.Orders;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Orders
{
    public class EfGetOrdersQuery : EfUseCase,IGetOrdersQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetOrdersQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 51;

        public string Name => "Search Orders";

        public PagedResponse<OrderDTO> Execute(SearchOrder search)
        {
            return _response.ReturnPagedResponse<Order, OrderDTO, SearchOrder>(search, Context, (query, search) =>
            {
                if (search.UserId.HasValue)
                {
                   query = query.Where(x => x.UserId == search.UserId);
                }
                if(search.OrderedAtFrom.HasValue)
                {
                    query = query.Where(x => x.OrderedAt >= search.OrderedAtFrom);
                }
                if(search.OrderedAtTo.HasValue)
                {
                    query = query.Where(x => x.OrderedAt <= search.OrderedAtTo);
                }
                if (search.PaymentTypeId.HasValue)
                {
                    query = query.Where(x => x.PaymentTypeId == search.PaymentTypeId);
                }
                if(search.ProductId.HasValue)
                {
                    query = query.Where(x => x.OrderItems.Any(x => x.ProductId == search.ProductId));
                }
                return query;
            },
           query => query.Select(x => new OrderDTO
           {
              Id = x.Id,
              OrderedAt = x.OrderedAt,
              PaymentType = x.PaymentType.Name,
              TotalPrice = x.TotalPrice,
              User = x.User.Username,
              Items = x.OrderItems.Select(x => new OrderItemDTO
              {
                  Id = x.Id,
                  Price = x.Price,
                  Product = x.Product.Name,
                  Quantity = x.Quantity
              })
           }).ToList());
        }
    }
}
