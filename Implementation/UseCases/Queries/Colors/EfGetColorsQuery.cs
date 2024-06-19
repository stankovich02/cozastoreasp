using Application.DTO.Brands;
using Application.DTO;
using Application.UseCases.Queries.Brands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Queries.Colors;
using Domain;
using Application.DTO.Colors;
using Application.DTO.Categories;

namespace Implementation.UseCases.Queries.Colors
{
    public class EfGetColorsQuery : EfUseCase, IGetColorsQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetColorsQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 26;

        public string Name => "Search Colors";

        public PagedResponse<ColorDTO> Execute(SearchColor search)
        {
            return _response.ReturnPagedResponse<Color, ColorDTO, SearchColor>(search, Context, (query, search) =>
            {
                return query.SearchEntity<Color>(search);
            },
            query => query.Select(x => new ColorDTO
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToList());
        }
    }
}
