using Application.DTO.Colors;
using Application.DTO.Genders;
using Application.Exceptions;
using Application.UseCases.Commands.Genders;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Colors;
using Implementation.Validators.Genders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Genders
{
    public class EfUpdateGenderCommand : EfUseCase,IUpdateGenderCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateGenderValidator _validator;
        public EfUpdateGenderCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateGenderValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Update Gender";

        public string Table => "Genders";

        public void Execute(UpdateGenderDTO data)
        {
            _genericUpdateService.UpdateEntity<Gender, UpdateGenderDTO, UpdateGenderValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.Name = dto.Name;
                });
        }
    }
}
