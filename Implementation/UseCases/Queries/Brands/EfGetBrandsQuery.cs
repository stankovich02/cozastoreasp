using Application.DTO;
using Application.DTO.Brands;
using Application.DTO.Categories;
using Application.UseCases.Queries.Brands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Brands
{
    public class EfGetBrandsQuery : EfUseCase, IGetBrandsQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetBrandsQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 25;

        public string Name => "Search Brands";

        public PagedResponse<BrandDTO> Execute(SearchBrand search)
        {

            return _response.ReturnPagedResponse<Brand, BrandDTO, SearchBrand>(search, Context,
            (query, search) =>
            {
                return query.SearchEntity<Brand>(search);
            },
            query => query.Select(x => new BrandDTO
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToList());
        }
    }
}
