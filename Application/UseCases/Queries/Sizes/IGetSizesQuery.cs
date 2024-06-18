using Application.DTO.PaymentTypes;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Sizes;

namespace Application.UseCases.Queries.Sizes
{
    public interface IGetSizesQuery : IQuery<PagedResponse<SizeDTO>, SearchSize>
    {
    }
}
