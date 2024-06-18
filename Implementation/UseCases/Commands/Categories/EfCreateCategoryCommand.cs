using Application.DTO.Categories;
using Application.UseCases.Commands.Categories;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateCategoryValidator _validator;
        public EfCreateCategoryCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreateCategoryValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Create category";

        public void Execute(CreateCategoryDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Category
                {
                    Name = data.Name,
                };
            });
        }
    }
}
