using Application.DTO.Orders;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator(CozaStoreContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.PaymentTypeId)
                .NotEmpty()
                .Must(x => context.PaymentTypes.Any(y => y.Id == x && y.IsActive))
                .WithMessage("Payment type doesn't exist");

            RuleFor(x => x.Products)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleForEach(x => x.Products).Must((x, product) =>
                    {
                        return context.Products.Any(y => y.Id == product.ProductId && y.IsActive);
                    }).WithMessage("Product doesn't exist.");

                })
                .Must(AllProductsAreUnique)
                .WithMessage("Only unique product ids must be delivered");
        }
        private bool AllProductsAreUnique(IEnumerable<ProductCartDTO> products) 
        {
            List<int> tempArray = new List<int>();

            foreach (var product in products) 
            {
                tempArray.Add(product.ProductId);
            }
            return tempArray.Distinct().Count() == tempArray.Count();
        }
    }
}
