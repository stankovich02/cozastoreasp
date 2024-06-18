using Application.DTO.Colors;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Genders;

namespace Application.UseCases.Queries.Genders
{
    public interface IGetGendersQuery : IQuery<PagedResponse<GenderDTO>, SearchGender>
    {
    }
}
