using Application.DTO.Genders;
using Application.DTO.PaymentTypes;
using Application.Exceptions;
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
    public class EfUpdatePaymentTypeCommand : EfUseCase,IUpdatePaymentTypeCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdatePaymentTypeValidator _validator;
        public EfUpdatePaymentTypeCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdatePaymentTypeValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Update Payment Type";

        public string Table => "Payment Types";

        public void Execute(UpdatePaymentTypeDTO data)
        {
            _genericUpdateService.UpdateEntity<PaymentType, UpdatePaymentTypeDTO, UpdatePaymentTypeValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.Name = dto.Name;
                });
        }
    }
}
