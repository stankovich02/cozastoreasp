using Application.DTO;
using Application.DTO.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Carts
{
    public interface IGetCartsQuery : IQuery<PagedResponse<CartDTO>,SearchCart>
    {
    }
}
