using Application.DTO.Brands;
using Application.Exceptions;
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
    public class EfGetBrandQuery : IGetBrandQuery
    {
        private readonly GenericSingleResponse _response;
        public EfGetBrandQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 60;

        public string Name => "Get single Brand";

        public string Table => "Brands";

        public BrandDTO Execute(int search)
        {
           return _response.ReturnSingle<Brand, BrandDTO>(search, entity => new BrandDTO
           {
               Id = entity.Id,
               Name = entity.Name,
               Status = entity.IsActive ? "Active" : "Inactive"
           });
        }
    }
}
