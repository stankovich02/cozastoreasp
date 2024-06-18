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
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator(CozaStoreContext context)
        {
            RuleFor(x => x.Name)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .MinimumLength(3)
                  .Must((dto, name) => !context.Products.Any(y => y.Name == name && y.Id != dto.Id))
                  .WithMessage("Product name already exists");

            RuleFor(x => x.Description)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .MinimumLength(10);

            RuleFor(x => x.CategoryId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Categories.Any(y => y.Id == x))
                   .WithMessage("Category doesnt exist.");

            RuleFor(x => x.BrandId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Brands.Any(y => y.Id == x))
                   .WithMessage("Brand doesnt exist.");

            RuleFor(x => x.GenderId)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .Must(x => context.Genders.Any(y => y.Id == x))
                   .WithMessage("Gender doesnt exist.");

            RuleFor(x => x.Available)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty()
                   .GreaterThan(-1)
                   .WithMessage("Available number of product cannot be negative value.");

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
                           return context.Sizes.Any(y => y.Id == sizeID);
                       }).WithMessage("Size ID doesn't exist.");
                   });
            RuleFor(x => x.Colors)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .WithMessage("At least one color is required.")
                  .DependentRules(() =>
                  {
                      RuleForEach(x => x.Colors).Must((x, sizeID) =>
                      {
                          return context.Colors.Any(y => y.Id == sizeID);
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
                           //primer 2 stare i jedna nova
                           //nova se proverava U temp-u
                           var tempPath = Path.Combine("wwwroot", "temp", fileName);
                           //2 stare se proveravaju u folderu gde se cuvaju
                           var savedPath = Path.Combine("wwwroot", "images", "products", fileName);
                           if(Path.Exists(tempPath) || Path.Exists(savedPath)){
                               return true;
                           }
                           return false;
                       }).WithMessage("Image doesn't exist.");
                   });
        }
    }
}
