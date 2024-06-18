using Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Products
{
    public interface IUpdateProductCommand : ICommand<UpdateProductDTO>
    {
    }
}
