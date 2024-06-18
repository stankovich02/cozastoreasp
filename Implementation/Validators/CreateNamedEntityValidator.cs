using Application.DTO;
using Application.DTO.Categories;
using DataAccess;
using FluentValidation;
using Implementation.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateNamedEntityValidator<TEntity, TDTO> : AbstractValidator<TDTO>
     where TEntity : class
     where TDTO : CreateNamedEntityDTO
    {
        public CreateNamedEntityValidator(CozaStoreContext context, string entityName)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"{entityName} is required.")
                .Must((dto, name) => !context.Set<TEntity>().Any(e => EF.Property<string>(e, "Name") == name))
                .WithMessage($"{entityName} with this name already exists.");
        }
    }
}
