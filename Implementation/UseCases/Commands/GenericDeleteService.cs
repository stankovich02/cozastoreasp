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

        public GenericDeleteService(CozaStoreContext context)
        {
            _context = context;
        }

        public void DeactivateEntity<TEntity>(int id, string entityName) where TEntity : Entity
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
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
