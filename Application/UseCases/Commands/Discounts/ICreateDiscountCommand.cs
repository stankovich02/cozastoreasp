using Application.DTO.Discounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Discounts
{
    public interface ICreateDiscountCommand : ICommand<CreateDiscountDTO>
    {
    }
}
