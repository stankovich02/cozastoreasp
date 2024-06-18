using Application.DTO;
using Application.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Categories
{
    public interface IGetCategoriesQuery : IQuery<PagedResponse<CategoryDTO>,SearchCategory>
    {
    }
}
