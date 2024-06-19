using Application.DTO;
using Application.Exceptions;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public class GenericSingleResponse : EfUseCase
    {
        public GenericSingleResponse(CozaStoreContext context) : base(context)
        {
        }

        public TDto ReturnSingle<TEntity, TDto>(int id, Func<TEntity,TDto> dataForReturn)
            where TDto : class, new()
            where TEntity : class
          
        {
            TEntity entity = Context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            if(entity is Entity e)
            {
                if (!e.IsActive)
                {
                    throw new EntityNotFoundException();
                }
            }

            TDto dto = dataForReturn(entity);

            return dto;

        }
    }
}
