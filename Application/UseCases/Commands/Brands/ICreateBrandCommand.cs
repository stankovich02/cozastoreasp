using Application.DTO.Brands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Brands
{
    public interface ICreateBrandCommand : ICommand<CreateBrandDTO>
    {
    }
}
