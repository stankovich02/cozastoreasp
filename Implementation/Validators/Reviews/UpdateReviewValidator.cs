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
            RuleFor(x => x.ReviewText)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Rate)
                .InclusiveBetween(1, 5);
        }
    }
}
