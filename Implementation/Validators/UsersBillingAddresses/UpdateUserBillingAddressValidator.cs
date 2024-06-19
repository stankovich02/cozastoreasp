using Application.DTO.UsersBillingAddresses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UsersBillingAddresses
{
    public class UpdateUserBillingAddressValidator : AbstractValidator<UpdateUserBillingAddressDTO>
    {
        public UpdateUserBillingAddressValidator() 
        {
            RuleFor(x => x.Phone)
               .NotEmpty()
               .Matches(@"^(\+[0-9]{3})?[0-9]{9}$")
               .WithMessage("Phone number is not in valid format.Example: +381651214574");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Matches(@"^[0-9]{5}$")
                .WithMessage("Zip code is not in valid format.Example: 11000");
        }
    }
}
