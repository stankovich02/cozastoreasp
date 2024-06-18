using Application.DTO.Categories;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Brands;

namespace Application.UseCases.Queries.Brands
{
    public interface IGetBrandsQuery : IQuery<PagedResponse<BrandDTO>, SearchBrand>
    {
    }
}
