using Application.DTO.Brands;
using Application.DTO.Categories;
using Application.UseCases.Queries.Categories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetCategoryQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 61;

        public string Name => "Get single Category";

        public string Table => "Categories";

        public CategoryDTO Execute(int search)
        {
            return _response.ReturnSingle<Category, CategoryDTO>(search, entity => new CategoryDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
