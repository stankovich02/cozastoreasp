using Application.DTO;
using Application.DTO.PaymentTypes;
using Application.DTO.Reviews;
using Application.UseCases.Queries.Reviews;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Reviews
{
    public class EfGetReviewsQuery : EfUseCase,IGetReviewsQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetReviewsQuery(GenericPagedResponse response,CozaStoreContext context)
            :base(context)
        {
            _response = response;
        }

        public int Id => 55;

        public string Name => "Search Reviews";

        public PagedResponse<ReviewDTO> Execute(SearchReview search)
        {
            return _response.ReturnPagedResponse<Review, ReviewDTO, SearchReview>(search, Context, (query, search) =>
            {
                if(search.ProductId.HasValue)
                {
                    query = query.Where(x => x.ProductId == search.ProductId);
                }
                if(search.Rate.HasValue)
                {
                    query = query.Where(x => x.Rate == search.Rate);
                }
                if(search.UserId.HasValue)
                {
                    query = query.Where(x => x.UserId == search.UserId);
                }
                if(search.ReviewedAtFrom.HasValue)
                {
                    query = query.Where(x => x.CreatedAt >= search.ReviewedAtFrom);
                }
                if(search.ReviewedAtTo.HasValue)
                {
                    query = query.Where(x => x.CreatedAt <= search.ReviewedAtTo);
                }
                return query;
            },
            query => query.Select(x => new ReviewDTO
            {
               Product = x.Product.Name,
               Rate = x.Rate,
               ReviewedAt = x.CreatedAt,
               ReviewText = x.ReviewText,
               User = x.User.Username
            }).ToList());
        }
    }
}
