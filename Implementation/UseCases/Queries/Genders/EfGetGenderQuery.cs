using Application.DTO.Genders;
using Application.UseCases.Queries.Genders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Genders
{
    public class EfGetGenderQuery : IGetGenderQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetGenderQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 64;

        public string Name => "Get single Gender";

        public string Table => "Genders";

        public GenderDTO Execute(int search)
        {
            return _response.ReturnSingle<Gender, GenderDTO>(search, entity => new GenderDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
