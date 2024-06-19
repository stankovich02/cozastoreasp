using Application.DTO.Reviews;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Reviews
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDTO>
    {
        public UpdateReviewValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ReviewText)
                .NotEmpty()
                .WithMessage("Review text is required.")
                .MinimumLength(5)
                .WithMessage("Review text must be at least 5 charachters long.");

            RuleFor(x => x.Rate)
                .InclusiveBetween(1, 5)
                .WithMessage("Rate must be between 1 and 5");
        }
    }
}
