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
                   .WithMessage("Full name is required.")
                   .Matches("(^[A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})")
                   .WithMessage("Invalid Full Name. Example: Jhon Doe");

            RuleFor(x => x.Email)
                   .NotEmpty()
                   .WithMessage("Email is required.")
                   .EmailAddress()
                   .WithMessage("Invalid Email. Example: jhondoe@gmail.com");
            
            RuleFor(x => x.Subject)
                  .NotEmpty()
                  .WithMessage("Subject is required.")
                  .MinimumLength(5)
                  .WithMessage("Subject must be at least 5 characters long.");

            RuleFor(x => x.MessageText)
                  .NotEmpty()
                  .WithMessage("Message is required.")
                  .MinimumLength(10)
                  .WithMessage("Message must be at least 10 characters long.");



        }
    }
}
