using Application.DTO.Colors;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.PaymentTypes;

namespace Application.UseCases.Queries.PaymentTypes
{
    public interface IGetPaymentTypesQuery : IQuery<PagedResponse<PaymentTypeDTO>, SearchPaymentType>
    {
    }
}
