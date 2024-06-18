using Application.DTO.Brands;
using Application.DTO.Categories;
using Application.UseCases.Commands.Brands;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Brands;
using Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Brands
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateBrandValidator _validator;
        public EfCreateBrandCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreateBrandValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Create Brand";

        public void Execute(CreateBrandDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Brand
                {
                    Name = data.Name,
                };
            });
        }
    }
}
