using Application.DTO.PaymentTypes;
using Application.DTO.Sizes;
using Application.UseCases.Queries.Sizes;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Sizes
{
    public class EfGetSizeQuery : IGetSizeQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetSizeQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 70;

        public string Name => "Get single Size";

        public string Table => "Sizes";

        public SizeDTO Execute(int search)
        {
            return _response.ReturnSingle<Size, SizeDTO>(search, entity => new SizeDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
