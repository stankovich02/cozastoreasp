using Application.DTO.Genders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Genders
{
    public interface IUpdateGenderCommand : ICommand<UpdateGenderDTO>
    {
    }
}
