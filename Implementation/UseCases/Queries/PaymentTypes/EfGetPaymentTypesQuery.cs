using Application.DTO.Genders;
using Application.DTO;
using Application.UseCases.Queries.Genders;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.PaymentTypes;
using Application.DTO.PaymentTypes;
using Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Application.DTO.Colors;

namespace Implementation.UseCases.Queries.PaymentTypes
{
    public class EfGetPaymentTypesQuery : EfUseCase, IGetPaymentTypesQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetPaymentTypesQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 28;

        public string Name => "Search Payment Types";

        public PagedResponse<PaymentTypeDTO> Execute(SearchPaymentType search)
        {
            return _response.ReturnPagedResponse<PaymentType, PaymentTypeDTO, SearchPaymentType>(search, Context, (query, search) =>
            {
               return query.SearchEntity<PaymentType>(search);
            },
            query => query.Select(x => new PaymentTypeDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }
    }
}
