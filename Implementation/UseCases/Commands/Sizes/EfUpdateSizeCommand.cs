using Application.DTO.PaymentTypes;
using Application.DTO.Sizes;
using Application.Exceptions;
using Application.UseCases.Commands.Sizes;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.PaymentTypes;
using Implementation.Validators.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Sizes
{
    public class EfUpdateSizeCommand : EfUseCase,IUpdateSizeCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateSizeValidator _validator;
        public EfUpdateSizeCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateSizeValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Update Size";

        public void Execute(UpdateSizeDTO data)
        {
            _genericUpdateService.UpdateEntity<Size, UpdateSizeDTO, UpdateSizeValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.Name = dto.Name;
                });
        }
    }
}
