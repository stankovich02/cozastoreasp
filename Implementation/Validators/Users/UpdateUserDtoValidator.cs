using Application.DTO.Users;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDtoValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is requried.")
                .EmailAddress()
                .WithMessage("Invalid email. Example: jhondoe@gmail.com")
                .Must((dto, x) => !context.Users.Any(u => u.Email == x && u.Id != dto.Id))
                .WithMessage("Email is already in use.");


            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Example: jhondoe123")
                .Must((dto, x) => !context.Users.Any(u => u.Username == x && u.Id != dto.Id))
                .WithMessage("Username is already in use.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MinimumLength(3)
                .WithMessage("First name must be at least 3 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MinimumLength(3)
                .WithMessage("Last name must be at least 3 characters long.");
        }
    }
}
