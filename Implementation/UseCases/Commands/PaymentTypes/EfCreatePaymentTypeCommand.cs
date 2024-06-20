using Application.DTO.Genders;
using Application.DTO.PaymentTypes;
using Application.UseCases.Commands.PaymentTypes;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Genders;
using Implementation.Validators.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.PaymentTypes
{
    public class EfCreatePaymentTypeCommand : EfUseCase,ICreatePaymentTypeCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreatePaymentTypeValidator _validator;
        public EfCreatePaymentTypeCommand(CozaStoreContext context, GenericCreateService genericCreateService, CreatePaymentTypeValidator validator) : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Create Payment Type";

        public string Table => "Payment Types";

        public void Execute(CreatePaymentTypeDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new PaymentType
                {
                    Name = data.Name,
                };
            });
        }
    }
}
