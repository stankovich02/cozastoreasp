using Application.DTO.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Colors
{
    public interface ICreateColorCommand : ICommand<CreateColorDTO>
    {
    }
}
