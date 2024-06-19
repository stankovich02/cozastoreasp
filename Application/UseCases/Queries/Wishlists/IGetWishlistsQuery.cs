using Application.DTO;
using Application.DTO.Wishlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Wishlists
{
    public interface IGetWishlistsQuery : IQuery<PagedResponse<WishlistDTO>, SearchWishlist>
    {
    }
}
