using Application.DTO.PaymentTypes;
using Application.DTO.Sizes;
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
    public class EfCreateSizeCommand : EfUseCase,ICreateSizeCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateSizeValidator _validator;
        public EfCreateSizeCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreateSizeValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Create Size";

        public void Execute(CreateSizeDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Size
                {
                    Name = data.Name,
                };
            });
        }
    }
}
