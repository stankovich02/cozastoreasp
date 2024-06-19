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
    public class EfGetBrandQuery : EfUseCase,IGetBrandQuery
    {
        public EfGetBrandQuery(CozaStoreContext context) : base(context)
        {
        }

        public int Id => 60;

        public string Name => "Get single Brand";

        public BrandDTO Execute(int search)
        {
            Brand brand = Context.Brands.Find(search);

            if(brand == null || !brand.IsActive)
            {
                throw new EntityNotFoundException();
            }

            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name,
                IsActive = brand.IsActive
            };
        }
    }
}
