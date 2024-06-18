using Application.DTO.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.PaymentTypes
{
    public interface ICreatePaymentTypeCommand : ICommand<CreatePaymentTypeDTO>
    {
    }
}
