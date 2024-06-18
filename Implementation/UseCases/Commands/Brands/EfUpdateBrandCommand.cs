using Application.DTO.Brands;
using Application.DTO.Categories;
using Application.Exceptions;
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
    public class EfUpdateBrandCommand : EfUseCase,IUpdateBrandCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateBrandValidator _validator;
        public EfUpdateBrandCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateBrandValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Update Brand";

        public void Execute(UpdateBrandDTO data)
        {
            _genericUpdateService.UpdateEntity<Brand, UpdateBrandDTO, UpdateBrandValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.Name = dto.Name;
                });

        }
    }
}
