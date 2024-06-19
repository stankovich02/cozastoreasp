using Application.DTO.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Colors
{
    public interface IGetColorQuery : IQuery<ColorDTO, int>
    {
    }
}
