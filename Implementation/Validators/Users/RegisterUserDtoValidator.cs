using Application.DTO.Users;
using DataAccess;
using FluentValidation;
using Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDtoValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email. Example: jhondoe@gmail.com")
                .Must(x => !context.Users.Any(u => u.Email == x))
                .WithMessage("Email is already in use.");

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

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Password must contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number. Example: JhonDoe123");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Example: jhondoe123")
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username is already in use.");
        }
    }
}
