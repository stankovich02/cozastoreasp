using Application.DTO.PaymentTypes;
using Application.DTO;
using Application.UseCases.Queries.PaymentTypes;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.Sizes;
using Application.DTO.Sizes;
using Domain;

namespace Implementation.UseCases.Queries.Sizes
{
    public class EfGetSizesQuery : EfUseCase, IGetSizesQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetSizesQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 29;

        public string Name => "Search Sizes";

        public PagedResponse<SizeDTO> Execute(SearchSize search)
        {
            return _response.ReturnPagedResponse<Size, SizeDTO, SearchSize>(search, Context, (query, search) =>
            {
                return query.SearchEntity<Size>(search);
            },
            query => query.Select(x => new SizeDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }
    }
}
