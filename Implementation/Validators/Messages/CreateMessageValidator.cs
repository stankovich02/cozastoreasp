using Application.DTO.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Messages
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageDTO>
    {
        public CreateMessageValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.FullName)
                   .NotEmpty()
                   .Matches("(^[A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})")
                   .WithMessage("Invalid Full Name. Example: Jhon Doe");

            RuleFor(x => x.Email)
                   .NotEmpty()
                   .EmailAddress();
            
            RuleFor(x => x.Subject)
                  .NotEmpty()
                  .MinimumLength(5);

            RuleFor(x => x.MessageText)
                  .NotEmpty()
                  .MinimumLength(10);



        }
    }
}
