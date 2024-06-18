using Application.DTO;
using Application.DTO.Categories;
using Application.DTO.Users;
using Application.UseCases.Queries.Categories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoriesQuery : EfUseCase,IGetCategoriesQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetCategoriesQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 9;

        public string Name => "Search Categories";

        public PagedResponse<CategoryDTO> Execute(SearchCategory search)
        {
            return _response.ReturnPagedResponse<Category, CategoryDTO, SearchCategory>(search, Context ,
            (query, search) =>
            {
               return query.SearchEntity<Category>(search);
            },
            query => query.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }
    }
   

}
