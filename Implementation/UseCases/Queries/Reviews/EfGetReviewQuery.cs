using Application.DTO.PaymentTypes;
using Application.DTO.Reviews;
using Application.UseCases.Queries.Reviews;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Reviews
{
    public class EfGetReviewQuery : IGetReviewQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetReviewQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 69;

        public string Name => "Get single Review";

        public ReviewDTO Execute(int search)
        {
            return _response.ReturnSingle<Review, ReviewDTO>(search, entity => new ReviewDTO
            {
                Product = entity.Product.Name,
                Rate = entity.Rate,
                ReviewedAt = entity.CreatedAt,
                ReviewText = entity.ReviewText,
                Status = entity.IsActive ? "Active" : "Inactive",
                User = entity.User.Username
            });
        }
    }
}
