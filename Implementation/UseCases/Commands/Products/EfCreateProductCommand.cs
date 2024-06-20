using Application.DTO.Categories;
using Application.DTO.Products;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Commands.Products;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Products
{
    public class EfCreateProductCommand : EfUseCase,ICreateProductCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateProductValidator _validator;

        public EfCreateProductCommand(CozaStoreContext context, CreateProductValidator validator, GenericCreateService genericCreateService) : base(context)
        {
            _validator = validator;
            _genericCreateService = genericCreateService;
        }

        public int Id => 30;

        public string Name => "Create Product";

        public string Table => "Products";

        public void Execute(CreateProductDTO data)
        {
            _validator.ValidateAndThrow(data);

            foreach (var file in data.Images)
            {
                var tempFile = Path.Combine("wwwroot", "temp", file);
                var destinationFile = Path.Combine("wwwroot", "images", "products", file);
                File.Move(tempFile, destinationFile);
            }

            Product p = new()
            {
                Name = data.Name,
                Description = data.Description,
                CategoryId = data.CategoryId,
                GenderId = data.GenderId,
                BrandId = data.BrandId,
                Available = data.Available,
                Prices = new List<Price>
                {
                    new() {
                        ProductPrice = data.Price,
                        DateFrom = DateTime.UtcNow,
                        DateTo = null
                    }
                },
                Sizes = data.Sizes.Select(s => new ProductSize
                {
                    SizeId = s
                }).ToList(),
                Colors = data.Colors.Select(c => new ProductColor
                {
                    ColorId = c
                }).ToList(),
                Images = data.Images.Select(i => new ProductImage
                {
                    Image = new Image
                    {
                        Path = $"/images/products/{i}"
                    }
                }).ToList()
            };

            Context.Products.Add(p);

            Context.SaveChanges();
        }
    }
}
