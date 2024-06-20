using Application.DTO.Brands;
using Application.DTO.Colors;
using Application.Exceptions;
using Application.UseCases.Commands.Colors;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Brands;
using Implementation.Validators.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Colors
{
    public class EfUpdateColorCommand : EfUseCase,IUpdateColorCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateColorValidator _validator;
        public EfUpdateColorCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateColorValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Update Color";

        public string Table => "Colors";

        public void Execute(UpdateColorDTO data)
        {
            _genericUpdateService.UpdateEntity<Color, UpdateColorDTO, UpdateColorValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.Name = dto.Name;
                });
        }
    }
}
