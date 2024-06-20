using Application.DTO.Colors;
using Application.DTO.Discounts;
using Application.UseCases.Queries.Discounts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Discounts
{
    public class EfGetDiscountQuery : IGetDiscountQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetDiscountQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 63;

        public string Name => "Get single Discount";

        public string Table => "Discounts";

        public DiscountDTO Execute(int search)
        {
            return _response.ReturnSingle<Discount, DiscountDTO>(search, entity => new DiscountDTO
            {
               Id = entity.Id,
               DateFrom = entity.DateFrom,
               DateTo = entity.DateTo,
               DiscountPercent = entity.DiscountPercent,
               Product = entity.Product.Name,
               Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
