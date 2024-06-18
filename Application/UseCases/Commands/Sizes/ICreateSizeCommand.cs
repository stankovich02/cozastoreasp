using Application.DTO.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Sizes
{
    public interface ICreateSizeCommand : ICommand<CreateSizeDTO>
    {
    }
}
