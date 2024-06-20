using Application.DTO.Colors;
using Application.DTO;
using Application.UseCases.Queries.Colors;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.Genders;
using Domain;
using Application.DTO.Genders;

namespace Implementation.UseCases.Queries.Genders
{
    public class EfGetGendersQuery : EfUseCase, IGetGendersQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetGendersQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 27;

        public string Name => "Search Genders";

        public string Table => "Genders";

        public PagedResponse<GenderDTO> Execute(SearchGender search)
        {
            return _response.ReturnPagedResponse<Gender, GenderDTO, SearchGender>(search, Context, (query, search) =>
            {
                return query.SearchEntity<Gender>(search);
            },
            query => query.Select(x => new GenderDTO
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToList());
        }
    }
}
