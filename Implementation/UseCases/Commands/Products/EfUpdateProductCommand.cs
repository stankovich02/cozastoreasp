using Application.DTO.Products;
using Application.DTO.Sizes;
using Application.UseCases.Commands.Products;
using DataAccess;
using Domain;
using Implementation.Validators.Products;
using Implementation.Validators.Sizes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Products
{
    public class EfUpdateProductCommand : EfUseCase,IUpdateProductCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateProductValidator _validator;

        public EfUpdateProductCommand(CozaStoreContext context, GenericUpdateService genericUpdateService, UpdateProductValidator validator) : base(context)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Update Product";

        public void Execute(UpdateProductDTO data)
        {
            _genericUpdateService.UpdateEntity<Product, UpdateProductDTO, UpdateProductValidator>(data, _validator,
               (entity, dto) =>
               {

                   Price activePrice = Context.Prices.Where(x => x.DateTo == null && x.IsActive && x.ProductId == dto.Id).FirstOrDefault();
                   if(activePrice.ProductPrice != data.Price)
                   {
                       activePrice.DateTo = DateTime.UtcNow;
                       activePrice.IsActive = false;
                       entity.Prices = new List<Price>
                        {
                            new Price
                            {
                                ProductPrice = data.Price,
                                DateFrom = DateTime.UtcNow,
                                DateTo = null
                            }
                        };
                   }
                   Context.SaveChanges();
                   entity.Name = data.Name;
                   entity.Description = data.Description;
                   entity.Available = data.Available;
                   entity.CategoryId = data.CategoryId;
                   entity.BrandId = data.BrandId;
                   entity.GenderId = data.GenderId;
                   var currentSizes = Context.ProductSizes.Where(ps => ps.ProductId == entity.Id).ToList();
                   Context.ProductSizes.RemoveRange(currentSizes);
                   var currentColors = Context.ProductColors.Where(ps => ps.ProductId == entity.Id).ToList();
                   Context.ProductColors.RemoveRange(currentColors);
                   Context.SaveChanges();

                   entity.Sizes = data.Sizes.Select(s => new ProductSize
                   {
                       SizeId = s
                   }).ToList();
                   entity.Colors = data.Colors.Select(c => new ProductColor
                   {
                       ColorId = c
                   }).ToList();
                   //slika3.jpg sliak4.jpg slika5.jpg
                   //slika1.jpg(nova) slika2.jpg(nova) slika3.jpg(stara)
                   //novi niz - slik1.jpg,slika2.jpg
                   List<ProductImage> images = new List<ProductImage> { };
                   var oldImages = Context.ProductImages.Where(ps => ps.ProductId == entity.Id).Select(x => x.Image.Path).ToList();
                   foreach(var image in data.Images)
                   {
                       if (!oldImages.Contains($"/images/products/{image}"))
                       {
                           var tempFile = Path.Combine("wwwroot", "temp", image);
                           var destinationFile = Path.Combine("wwwroot", "images", "products", image);
                           File.Move(tempFile, destinationFile);
                           images.Add(new ProductImage 
                           {  
                               Image = new Image 
                                { 
                                   Path = $"/images/products/{image}"
                                } 
                           });
                       }
                   }
                   foreach(ProductImage image in images)
                   {
                       entity.Images.Add(image);
                   }
                   foreach(string path in oldImages)
                   {
                       if (!data.Images.Contains(path.Split("/images/products/")[1]))
                       {
                           Image oldImg = Context.Images.Where(x => x.Path == path).FirstOrDefault();

                           Context.Images.Remove(oldImg);

                           var fullPath = Path.Combine("wwwroot", path.TrimStart('/'));
                           if (File.Exists(fullPath))
                           {
                               File.Delete(fullPath);
                           }
                       }
                   }
                   Context.SaveChanges();

               });
        }
    }
}
