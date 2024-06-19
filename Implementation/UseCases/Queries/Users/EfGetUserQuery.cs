using Application.DTO.Sizes;
using Application.DTO.Users;
using Application.UseCases.Queries.Users;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Users
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetUserQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 71;

        public string Name => "Get single User";

        public UserDTO Execute(int search)
        {
            return _response.ReturnSingle<User, UserDTO>(search, entity => new UserDTO
            {
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Id = entity.Id,
                OrdersCount = entity.Orders.Count(),
                ImagePath = entity.Image.Path,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
