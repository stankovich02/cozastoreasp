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
        private readonly CozaStoreContext _context;
        public UpdateUserDtoValidator(CozaStoreContext context)
        {
            _context = context;

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                .Must((dto, x) => !context.Users.Any(u => u.Email == x && u.Id != dto.Id))
                .WithMessage("Email is already in use.");


            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Example: jhondoe123")
                .Must((dto, x) => !context.Users.Any(u => u.Username == x && u.Id != dto.Id))
                .WithMessage("Username is already in use.");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
