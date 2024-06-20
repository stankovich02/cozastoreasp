using Application.DTO.Brands;
using Application.DTO.Colors;
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
    public class EfCreateColorCommand : EfUseCase,ICreateColorCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateColorValidator _validator;
        public EfCreateColorCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreateColorValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Color";

        public string Table => "Colors";

        public void Execute(CreateColorDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Color
                {
                    Name = data.Name,
                };
            });
        }
    }
}
