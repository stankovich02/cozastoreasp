using Application.DTO;
using Application.DTO.Carts;
using Application.DTO.Users;
using Application.UseCases.Queries.Carts;
using Azure;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Carts
{
    public class EfGetCartsQuery : EfUseCase,IGetCartsQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetCartsQuery(GenericPagedResponse response,CozaStoreContext context)
            : base(context)
        {
            _response = response;
        }

        public int Id => 48;

        public string Name => "Search Carts";

        public string Table => "Carts";

        public PagedResponse<CartDTO> Execute(SearchCart search)
        {
            return _response.ReturnPagedResponse<Cart, CartDTO, SearchCart>(search, Context, (query, search) =>
            {
                if (search.UserId.HasValue)
                {
                   query = query.Where(x => x.UserId == search.UserId);
                }
                if(search.ProductId.HasValue)
                {
                    query = query.Where(x => x.ProductId == search.ProductId);
                }
                return query;
            },
           query => query.Select(x => new CartDTO
           {
              Product = x.Product.Name,
              Quantity = x.Quantity,
              User = x.User.Username
           }).ToList());
        }
    }
}
