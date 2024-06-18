using Application.DTO;
using Application.Exceptions;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class GenericCreateService(CozaStoreContext context)
    {
        private readonly CozaStoreContext _context = context;

        public void CreateEntity<TEntity, TDto, TValidator>(TDto dto, TValidator validator,Func<TDto,TEntity> insertEntity)
        where TValidator : AbstractValidator<TDto>
        where TEntity : Entity, new()
        where TDto : class
        {
            validator.ValidateAndThrow(dto);

            _context.Set<TEntity>().Add(insertEntity(dto));
          
            _context.SaveChanges();
        }
    }
}
