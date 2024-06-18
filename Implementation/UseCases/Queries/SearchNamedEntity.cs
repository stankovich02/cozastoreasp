using Application.DTO;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public static class SearchNamedEntity
    {
        public static IQueryable<TEntity> SearchEntity<TEntity>(this IQueryable<TEntity> query, SearchNamedEntityDTO search)
            where TEntity : NamedEntity
        {
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => EF.Property<string>(x, "Name").ToLower().Contains(search.Name.ToLower()));
            }

            if (search.IsActive.HasValue)
            {
                if (search.IsActive.Value)
                {
                    query = query.Where(x => EF.Property<bool>(x, "IsActive"));
                }
                else
                {
                    query = query.Where(x => !EF.Property<bool>(x, "IsActive"));
                }
            }

            return query;
        }
    }
}
