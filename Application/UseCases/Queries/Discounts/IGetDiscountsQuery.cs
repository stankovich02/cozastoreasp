using Application.DTO;
using Application.DTO.Discounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Discounts
{
    public interface IGetDiscountsQuery : IQuery<PagedResponse<DiscountDTO>,SearchDiscount>
    {
    }
}
