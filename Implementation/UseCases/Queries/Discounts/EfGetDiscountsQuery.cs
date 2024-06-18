using Application.DTO;
using Application.DTO.Discounts;
using Application.DTO.Products;
using Application.UseCases.Queries.Discounts;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Discounts
{
    public class EfGetDiscountsQuery : EfUseCase,IGetDiscountsQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetDiscountsQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }
        public int Id => 37;

        public string Name => "Search Discounts";

        public PagedResponse<DiscountDTO> Execute(SearchDiscount search)
        {
            return _response.ReturnPagedResponse<Discount, DiscountDTO, SearchDiscount>(search, Context, (query, search) =>
            {
                if(search.ProductId.HasValue && search.ProductId.Value > 0)
                {
                    query = query.Where(x => x.ProductId == search.ProductId);
                }
                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.DateFrom >= search.DateFrom);
                }
                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.DateTo <= search.DateTo);
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
                return query;
            },
          query => query.Select(x => new DiscountDTO
          {
             Product = x.Product.Name,
             DiscountPercent = x.DiscountPercent,
             DateFrom = x.DateFrom,
             DateTo = x.DateTo,
          }).ToList());
        }
    }
}
