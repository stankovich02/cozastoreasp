using Application.DTO.Sizes;
using Application.DTO.UsersBillingAddresses;
using Application.UseCases.Queries.UsersBillingAddresses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UsersBillingAddresses
{
    public class EfGetUserBillingAddressQuery : IGetUserBillingAddressQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetUserBillingAddressQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 72;

        public string Name => "Get single User billing address";

        public UserBillingAddressDTO Execute(int search)
        {
            return _response.ReturnSingle<UserBillingAddress, UserBillingAddressDTO>(search, entity => new UserBillingAddressDTO
            {
                Address = entity.Address,
                City = entity.City,
                Country = entity.Country,
                Phone = entity.Phone,
                User = entity.User.Username,
                ZipCode = entity.ZipCode,
                Status = entity.IsActive ? "Active" : "Inactive"
            });
        }
    }
}
