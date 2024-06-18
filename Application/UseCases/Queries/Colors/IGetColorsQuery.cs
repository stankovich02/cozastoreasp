using Application.DTO.Brands;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Colors;

namespace Application.UseCases.Queries.Colors
{
    public interface IGetColorsQuery : IQuery<PagedResponse<ColorDTO>, SearchColor>
    {
    }
}
