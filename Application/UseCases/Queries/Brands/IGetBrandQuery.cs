using Application.DTO.Brands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Brands
{
    public interface IGetBrandQuery : IQuery<BrandDTO,int>
    {
    }
}
