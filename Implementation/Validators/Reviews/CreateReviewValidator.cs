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
    public class CreateReviewValidator : AbstractValidator<CreateReviewDTO>
    {
        public CreateReviewValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .Must(x => context.Products.Any(y => y.Id == x && y.IsActive))
                .WithMessage("Product doesn't exist");

            RuleFor(x => x.ReviewText)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Rate)
                .InclusiveBetween(1, 5);
        }
    }
}
