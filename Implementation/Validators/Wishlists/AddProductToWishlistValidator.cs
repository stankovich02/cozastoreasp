using Application.DTO.Wishlists;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Wishlists
{
    public class AddProductToWishlistValidator : AbstractValidator<AddProductToWishlistDTO>
    {
        public AddProductToWishlistValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .Must(x => context.Products.Any(y => y.Id == x && y.IsActive))
                .WithMessage("Product doesn't exist.");
            
        }
    }
}
