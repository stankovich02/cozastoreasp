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
    public class CreateCartValidator : AbstractValidator<AddProductToCartDTO>
    {
        public CreateCartValidator(CozaStoreContext context)
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .Must(x => context.Products.Any(p => p.Id == x && p.IsActive))
                .WithMessage("Product does not exist.");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
