﻿using Application.DTO.Products;
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
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Name is required.")
                  .MinimumLength(3)
                  .WithMessage("Name must be at least 3 charachters long.")
                  .Must((dto, name) => !context.Products.Any(y => y.Name == name && y.Id != dto.Id))
                  .WithMessage("Product name already exists");

            RuleFor(x => x.Description)
                   .NotEmpty()
                   .WithMessage("Description is required.")
                   .MinimumLength(10)
                   .WithMessage("Description must be at least 10 charachters long.");

            RuleFor(x => x.CategoryId)
                   .NotEmpty()
                   .WithMessage("Category is required.")
                   .Must(x => context.Categories.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Category doesnt exist.");

            RuleFor(x => x.BrandId)
                   .NotEmpty()
                   .WithMessage("Brand is required.")
                   .Must(x => context.Brands.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Brand doesnt exist.");

            RuleFor(x => x.GenderId)
                   .NotEmpty()
                   .WithMessage("Gender is required.")
                   .Must(x => context.Genders.Any(y => y.Id == x && y.IsActive))
                   .WithMessage("Gender doesnt exist.");

            RuleFor(x => x.Available)
                   .NotEmpty()
                   .WithMessage("Number of available products is required.")
                   .GreaterThan(-1)
                   .WithMessage("Available number of product cannot be negative value.");

            RuleFor(x => x.Price)
                   .NotEmpty()
                   .WithMessage("Price is required.")
                   .GreaterThan(0)
                   .WithMessage("Price cannot be negative value.");

            RuleFor(x => x.Sizes)
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
                   .NotEmpty()
                   .WithMessage("At least one image is required.")
                   .DependentRules(() =>
                   {
                       RuleForEach(x => x.Images).Must((x, fileName) =>
                       {
                           var tempPath = Path.Combine("wwwroot", "temp", fileName);
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
