using Application;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Commands
{
    public class GenericUpdateService
    {
        private readonly CozaStoreContext _context;
        private readonly IApplicationActor _actor;

        public GenericUpdateService(CozaStoreContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public void UpdateEntity<TEntity, TDto, TValidator>(TDto dto, TValidator validator, Action<TEntity,TDto> updateAction)
        where TValidator : AbstractValidator<TDto>
            where TEntity : Entity, new()
        where TDto : UpdateEntityDTO
        {
            TEntity entity = _context.Set<TEntity>().Find(dto.Id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            if (entity is UserBillingAddress userBillingAddress)
            {
                if (userBillingAddress.UserId != _actor.Id)
                {
                    throw new ConflictException("You cannot update other user billing address.");
                }
            }

            validator.ValidateAndThrow(dto);

            updateAction(entity, dto);

            _context.SaveChanges();
        }
    }
}
