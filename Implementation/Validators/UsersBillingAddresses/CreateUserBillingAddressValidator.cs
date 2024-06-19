using Application.DTO.UsersBillingAddresses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UsersBillingAddresses
{
    public class CreateUserBillingAddressValidator : AbstractValidator<CreateUserBillingAddressDTO>
    {
        public CreateUserBillingAddressValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required.")
                .Matches(@"^(\+[0-9]{3})?[0-9]{9}$")
                .WithMessage("Phone number is not in valid format. Example: +381651214574");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(100)
                .WithMessage("Address too long.");

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country is required.")
                .MaximumLength(50)
                .WithMessage("Country too long.");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(50)
                .WithMessage("City too long.");

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage("ZipCode is required.")
                .Matches(@"^[0-9]{5}$")
                .WithMessage("Zip code is not in valid format.Example: 11000");
        }
    }
}
