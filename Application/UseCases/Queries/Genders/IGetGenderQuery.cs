using Application.DTO.Genders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Genders
{
    public interface IGetGenderQuery : IQuery<GenderDTO,int>
    {
    }
}
