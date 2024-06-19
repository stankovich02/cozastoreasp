using Application.DTO.Discounts;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Discounts
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountDTO>
    {
        public CreateDiscountValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId)
                   .NotEmpty()
                   .Must(x => context.Products.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Product doesn't exist.");

            RuleFor(x => x.DiscountPercent)
                   .NotEmpty()
                   .GreaterThan(0);

            RuleFor(x => x.DateFrom)
                   .NotEmpty()
                   .Must(x => (x - DateTime.UtcNow).TotalHours > 1)
                   .WithMessage("Start date of discount must be at least 1 hour from now.");

            RuleFor(x => x.DateTo)
                   .NotEmpty()
                   .Must((dto, dateTo) => dateTo > dto.DateFrom)
                   .When(dto => dto.DateFrom != default)
                   .WithMessage("End date cannot be before start date.")
                   .Must(x => (x - DateTime.UtcNow).TotalHours > 24)
                   .WithMessage("End date of discount must be at least 24 hours from now.");

        }
    }
}
