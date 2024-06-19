using Application.DTO.Categories;
using Application.DTO.Colors;
using Application.UseCases.Queries.Colors;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Colors
{
    public class EfGetColorQuery : IGetColorQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetColorQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 62;

        public string Name => "Get single Color";

        public ColorDTO Execute(int search)
        {
            return _response.ReturnSingle<Color, ColorDTO>(search, entity => new ColorDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
