using Application.DTO;
using Application.DTO.PaymentTypes;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public class GenericPagedResponse
    {
        public PagedResponse<TDto> ReturnPagedResponse<TEntity, TDto, TSearch>(TSearch search, CozaStoreContext context, Func<IQueryable<TEntity>, TSearch, IQueryable<TEntity>> searchAction,Func<IQueryable<TEntity>,IEnumerable<TDto>> dataForReturn)
       where TSearch : PagedSearch
       where TDto : class, new()
       where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();


            query = searchAction(query, search);

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalCount = query.Count();

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<TDto>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage,
                Data = dataForReturn(query),
            };

        }
    }
}
