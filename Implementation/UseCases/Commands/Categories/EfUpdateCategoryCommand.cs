using Application.DTO;
using Application.DTO.Categories;
using Application.Exceptions;
using Application.UseCases.Commands.Categories;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Categories
{
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateCategoryValidator _validator;
        public EfUpdateCategoryCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateCategoryValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Update category";

        public string Table => "Categories";

        public void Execute(UpdateCategoryDTO data)
        {
           
            _genericUpdateService.UpdateEntity<Category,UpdateCategoryDTO,UpdateCategoryValidator>(data,_validator,
                (entity,dto) => 
                {
                    entity.Name = dto.Name;
                });
        }
        
    }
}
