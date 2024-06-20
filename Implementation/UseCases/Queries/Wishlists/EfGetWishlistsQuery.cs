using Application.DTO;
using Application.DTO.Carts;
using Application.DTO.Wishlists;
using Application.UseCases.Queries.Wishlists;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Wishlists
{
    public class EfGetWishlistsQuery : EfUseCase,IGetWishlistsQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetWishlistsQuery(GenericPagedResponse response,CozaStoreContext context)
            : base(context)
        {
            _response = response;
        }

        public int Id => 58;

        public string Name => "Search Wishlists";

        public string Table => "Wishlists";

        public PagedResponse<WishlistDTO> Execute(SearchWishlist search)
        {
            return _response.ReturnPagedResponse<Wishlist, WishlistDTO, SearchWishlist>(search, Context, (query, search) =>
            {
                if (search.UserId.HasValue)
                {
                    query = query.Where(x => x.UserId == search.UserId);
                }
                if (search.ProductId.HasValue)
                {
                    query = query.Where(x => x.ProductId == search.ProductId);
                }
                return query;
            },
          query => query.Select(x => new WishlistDTO
          {
              Product = x.Product.Name,
              User = x.User.Username
          }).ToList());
        }
    }
}
