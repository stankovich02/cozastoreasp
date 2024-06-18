using Application.DTO.PaymentTypes;
using Application.DTO.Sizes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Sizes
{
    public class CreateSizeValidator : CreateNamedEntityValidator<Size, CreateSizeDTO>
    {
        public CreateSizeValidator(CozaStoreContext context) : base(context, "Size")
        {

        }
    }
}
