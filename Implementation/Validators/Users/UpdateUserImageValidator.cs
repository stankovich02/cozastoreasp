using Application.DTO.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Users
{
    public class UpdateUserImageValidator : AbstractValidator<UpdateUserImageDTO>
    {
        public UpdateUserImageValidator()
        {
            RuleFor(x => x.File)
                .NotEmpty()
                .WithMessage("Image is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.File).Must((x, fileName) =>
                    {
                        var path = Path.Combine("wwwroot", "temp", fileName);

                        var exists = Path.Exists(path);

                        return exists;
                    }).WithMessage("File doesn't exist.");
                });
        }
    }
}
