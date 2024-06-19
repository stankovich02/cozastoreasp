using Application.DTO;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UpdateNamedEntityValidator<TEntity, TDTO> : AbstractValidator<TDTO>
     where TEntity : class
     where TDTO : UpdateNamedEntityDTO
    {
        public UpdateNamedEntityValidator(CozaStoreContext context, string entityName)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"{entityName} is required.")
                .MinimumLength(3)
                .WithMessage($"{entityName} must contain at least 3 characters.")
                .Must((dto, name) => !context.Set<TEntity>().Any(e => EF.Property<string>(e, "Name") == name && EF.Property<int>(e, "Id") != dto.Id))
                .WithMessage($"{entityName} with this name already exists.");
        }
    }
}
