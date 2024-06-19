using Application.DTO.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Carts
{
    public interface ICreateCartCommand : ICommand<AddProductToCartDTO>
    {
    }
}
