using Application.DTO.Genders;
using Application.DTO.PaymentTypes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.PaymentTypes
{
    public class UpdatePaymentTypeValidator : UpdateNamedEntityValidator<PaymentType, UpdatePaymentTypeDTO>
    {
        public UpdatePaymentTypeValidator(CozaStoreContext context) : base(context, "Payment Type")
        {
        }
    }
}
