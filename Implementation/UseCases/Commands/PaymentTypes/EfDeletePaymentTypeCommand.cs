using Application.Exceptions;
using Application.UseCases.Commands.PaymentTypes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.PaymentTypes
{
    public class EfDeletePaymentTypeCommand : EfUseCase,IDeletePaymentTypeCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeletePaymentTypeCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 21;

        public string Name => "Delete Payment Type";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<PaymentType>(data, "Payment Type");

        }
    }
}
