using Application.DTO;
using Application.DTO.Products;
using Application.DTO.Users;
using Application.UseCases.Queries.Products;
using Azure;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Products
{
    public class EfGetProductsQuery : EfUseCase,IGetProductsQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetProductsQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 33;

        public string Name => "Search Products";

        public PagedResponse<ProductDTO> Execute(SearchProduct search)
        {
            return _response.ReturnPagedResponse<Product, ProductDTO, SearchProduct>(search, Context, (query, search) =>
            {
                if (search.IsActive.HasValue)
                {
                    if (search.IsActive.Value)
                    {
                        query = query.Where(x => x.IsActive);
                    }
                    else
                    {
                        query = query.Where(x => !x.IsActive);
                    }
                }
                return query;
            },
          query => query.Select(x => new ProductDTO
          {
             Id = x.Id,
             Brand = x.Brand.Name,
             Category = x.Category.Name,
             Gender = x.Gender.Name,
             Sizes = x.Sizes.Select(x => x.Size.Name).ToList(),
             Colors = x.Colors.Select(x => x.Color.Name).ToList(),
             Description = x.Description,
             AverageRating = x.Reviews.Any() ? x.Reviews.Sum(x => x.Rate) / x.Reviews.Count() : 0,
             Discount = x.Discounts.Where(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive).Select(d => d.DiscountPercent).FirstOrDefault(),
             Images = x.Images.Select(x => x.Image.Path).ToList(),
             InStock = x.Available > 0,
             Name = x.Name,
             Price = x.Prices.Where(y => y.DateTo == null && y.IsActive).Select(p => new ProductPriceDTO
             {
                OldPrice = x.Discounts.Any(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive) ? p.ProductPrice : null,
                ActivePrice = 
                x.Discounts.Any(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow && d.IsActive) ? p.ProductPrice - (p.ProductPrice * x.Discounts
                                                                                                                                .Where(d => d.DateFrom <= DateTime.UtcNow && d.DateTo > DateTime.UtcNow)
                                                                                                                                .Select(d => d.DiscountPercent)
                                                                                                                                .FirstOrDefault() / 100) : p.ProductPrice
             }).FirstOrDefault(),
             Reviews = x.Reviews.Select(x => new ReviewDTO
             {
                 Id = x.Id,
                 Avatar = x.User.Image.Path,
                 Comment = x.ReviewText,
                 CommentedAt = x.CreatedAt,
                 Rating = x.Rate,
                 User = x.User.FirstName + " " + x.User.LastName,
             }).ToList()
        }).ToList());
        }
    }
}
