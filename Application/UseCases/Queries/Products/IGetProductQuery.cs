using Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Products
{
    public interface IGetProductQuery : IQuery<ProductDTO, int>
    {
    }
}
