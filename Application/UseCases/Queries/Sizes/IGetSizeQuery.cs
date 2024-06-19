using Application.DTO.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Sizes
{
    public interface IGetSizeQuery : IQuery<SizeDTO, int>
    {
    }
}
