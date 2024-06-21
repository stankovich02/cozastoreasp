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

        public string Table => "Products";

        public PagedResponse<ProductDTO> Execute(SearchProduct search)
        {
            return _response.ReturnPagedResponse<Product, ProductDTO, SearchProduct>(search, Context, (query, search) =>
            {
                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
                }
                if (search.BrandIds != null && search.BrandIds.Any())
                {
                    query = query.Where(x => search.BrandIds.Contains(x.BrandId));
                }
                if (search.ColorIds != null && search.ColorIds.Any())
                {
                    query = query.Where(x => x.Colors.Any(c => search.ColorIds.Contains(c.ColorId)));
                }
                if (search.SizeIds != null && search.SizeIds.Any())
                {
                    query = query.Where(x => x.Sizes.Any(s => search.SizeIds.Contains(s.SizeId)));
                }
                if (search.CategoryId.HasValue)
                {
                    query = query.Where(x => x.CategoryId == search.CategoryId);
                }
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
                if (!string.IsNullOrEmpty(search.Sort))
                {
                    switch (search.Sort)
                    {
                        case "price-asc":
                            query = query.OrderBy(x => x.Prices.OrderByDescending(x => x.CreatedAt).FirstOrDefault().ProductPrice);
                            break;
                        case "price-desc":
                            query = query.OrderByDescending(x => x.Prices.OrderByDescending(x => x.CreatedAt).FirstOrDefault().ProductPrice);
                            break;
                        case "rating":
                            query = query.OrderByDescending(x => x.Reviews.Any() ? x.Reviews.Sum(x => x.Rate) / x.Reviews.Count() : 0);
                            break;
                        case "latest":
                            query = query.OrderByDescending(x => x.Id);
                            break;
                        default:
                            query = query.OrderBy(x => x.Id);
                            break;
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
             Status = x.IsActive ? "Active" : "Inactive",
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
