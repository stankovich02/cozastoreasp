using Application.DTO.Wishlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Wishlists
{
    public interface IAddProductToWishlistCommand : ICommand<AddProductToWishlistDTO>
    {
    }
}
