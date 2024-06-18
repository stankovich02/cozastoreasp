using Application.DTO.Colors;
using Application.DTO.Genders;
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
    public class EfCreateGenderCommand : EfUseCase,ICreateGenderCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateGenderValidator _validator;
        public EfCreateGenderCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreateGenderValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Create Gender";

        public void Execute(CreateGenderDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Gender
                {
                    Name = data.Name,
                };
            });
        }
    }
}
