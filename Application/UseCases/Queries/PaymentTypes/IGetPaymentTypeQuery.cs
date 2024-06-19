using Application.DTO.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.PaymentTypes
{
    public interface IGetPaymentTypeQuery : IQuery<PaymentTypeDTO, int>
    {
    }
}
