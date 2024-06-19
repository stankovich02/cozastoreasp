using Application.DTO.PaymentTypes;
using Application.UseCases.Queries.PaymentTypes;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.PaymentTypes
{
    public class EfGetPaymentTypeQuery : IGetPaymentTypeQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetPaymentTypeQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 67;

        public string Name => "Get single Payment type";

        public PaymentTypeDTO Execute(int search)
        {
            return _response.ReturnSingle<PaymentType, PaymentTypeDTO>(search, entity => new PaymentTypeDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
