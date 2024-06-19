using Application.DTO.Carts;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Carts
{
    public class AddProductToCartValidator : AbstractValidator<AddProductToCartDTO>
    {
        public AddProductToCartValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product is required.")
                .Must(x => context.Products.Any(p => p.Id == x && p.IsActive))
                .WithMessage("Product does not exist.");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantity is required.")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");
        }
    }
}
