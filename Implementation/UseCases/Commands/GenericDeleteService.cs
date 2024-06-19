using Application;
using Application.Exceptions;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class GenericDeleteService
    {
        private readonly CozaStoreContext _context;
        private readonly IApplicationActor _actor;

        public GenericDeleteService(CozaStoreContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public void DeactivateEntity<TEntity>(int id, string entityName) where TEntity : Entity
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            if(entity is UserBillingAddress userBillingAddress)
            {
                if(userBillingAddress.UserId != _actor.Id)
                {
                    throw new ConflictException("You cannot delete other user billing address.");
                }
            }

            if (!entity.IsActive)
            {
                throw new ConflictException($"{entityName} is already deactivated.");
            }

            entity.IsActive = false;

            _context.SaveChanges();
        }
    }
}
