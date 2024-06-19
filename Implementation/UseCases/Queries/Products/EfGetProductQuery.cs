using Application.DTO.Products;
using Application.UseCases.Queries.Products;
using Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Products
{
    public class EfGetProductQuery : IGetProductQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetProductQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 68;

        public string Name => "Get single Product";

        public ProductDTO Execute(int search)
        {
            return _response.ReturnSingle<Product, ProductDTO>(search, entity => new ProductDTO
            {
                Id = entity.Id,
                Brand = entity.Brand.Name,
                Category = entity.Category.Name,
                Gender = entity.Gender.Name,
                Sizes = entity.Sizes.Select(x => x.Size.Name).ToList(),
                Colors = entity.Colors.Select(x => x.Color.Name).ToList(),
                Description = entity.Description,
                AverageRating = entity.Reviews.Any() ? x.Reviews.Sum(x => x.Rate) / x.Reviews.Count() : 0,
                Discount = entity.Discounts.Where(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive).Select(d => d.DiscountPercent).FirstOrDefault(),
                Images = entity.Images.Select(x => x.Image.Path).ToList(),
                InStock = entity.Available > 0,
                Status = entity.IsActive ? "Active" : "Inactive",
                Name = entity.Name,
                Price = entity.Prices.Where(y => y.DateTo == null && y.IsActive).Select(p => new ProductPriceDTO
                {
                    OldPrice = entity.Discounts.Any(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive) ? p.ProductPrice : null,
                    ActivePrice =
                   entity.Discounts.Any(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive) ? p.ProductPrice - (p.ProductPrice * x.Discounts
                                                                                                                                   .Where(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow)
                                                                                                                                   .Select(d => d.DiscountPercent)
                                                                                                                                   .FirstOrDefault() / 100) : p.ProductPrice
                }).FirstOrDefault(),
                Reviews = entity.Reviews.Select(x => new ReviewDTO
                {
                    Id = x.Id,
                    Avatar = x.User.Image.Path,
                    Comment = x.ReviewText,
                    CommentedAt = x.CreatedAt,
                    Rating = x.Rate,
                    User = x.User.FirstName + " " + x.User.LastName,
                }).ToList()
            });
        }
    }
}
