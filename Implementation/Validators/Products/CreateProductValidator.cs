using Application.DTO.Products;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator(CozaStoreContext context)
        {
            RuleFor(x => x.Name)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .MinimumLength(3)
                   .Must(x => !context.Products.Any(y => y.Name == x))
                   .WithMessage("Product name already exists");

            RuleFor(x => x.Description)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .MinimumLength(10);

            RuleFor(x => x.CategoryId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Categories.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Category doesnt exist.");

            RuleFor(x => x.BrandId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Brands.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Brand doesnt exist.");

            RuleFor(x => x.GenderId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Genders.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Gender doesnt exist.");

            RuleFor(x => x.Available)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithMessage("There has to be at least 1 product available.");

            RuleFor(x => x.Price)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithMessage("Price cannot be negative value.");

            RuleFor(x => x.Sizes)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .WithMessage("At least one size is required.")
                   .DependentRules(() =>
                   {
                       RuleForEach(x => x.Sizes).Must((x, sizeID) =>
                       {
                           return context.Sizes.Any(y => y.Id == sizeID && y.IsActive);
                       }).WithMessage("Size ID doesn't exist.");
                   });
            RuleFor(x => x.Colors)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .WithMessage("At least one color is required.")
                  .DependentRules(() =>
                  {
                      RuleForEach(x => x.Colors).Must((x, colorID) =>
                      {
                          return context.Colors.Any(y => y.Id == colorID && y.IsActive);
                      }).WithMessage("Color ID doesn't exist.");
                  });

            RuleFor(x => x.Images)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .WithMessage("At least one image is required.")
                   .DependentRules(() =>
                   {
                       RuleForEach(x => x.Images).Must((x, fileName) =>
                       {
                           var path = Path.Combine("wwwroot", "temp", fileName);

                           return Path.Exists(path);
                       }).WithMessage("Image doesn't exist.");
                   });
        }
    }
}
