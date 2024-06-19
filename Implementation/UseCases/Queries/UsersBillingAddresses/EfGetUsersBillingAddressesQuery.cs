using Application.DTO;
using Application.DTO.Users;
using Application.DTO.UsersBillingAddresses;
using Application.UseCases.Queries.UsersBillingAddresses;
using Azure;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.UsersBillingAddresses
{
    public class EfGetUsersBillingAddressesQuery : EfUseCase,IGetUsersBillingAddressesQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetUsersBillingAddressesQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 44;

        public string Name => "Search User billing addresses";

        public PagedResponse<UserBillingAddressDTO> Execute(SearchUserBillingAddress search)
        {
            return _response.ReturnPagedResponse<UserBillingAddress, UserBillingAddressDTO, SearchUserBillingAddress>(search, Context, (query, search) =>
            {
                if(search.UserId.HasValue)
                {
                    query = query.Where(x => x.UserId == search.UserId);
                }
                if(!string.IsNullOrEmpty(search.ZipCode))
                {
                    query = query.Where(x => x.ZipCode.ToLower().Contains(search.ZipCode.ToLower()));
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
           query => query.Select(x => new UserBillingAddressDTO
           {
              Address = x.Address,
              City = x.City,
              Country = x.Country,
              Phone = x.Phone,
              User = x.User.Username,
              ZipCode = x.ZipCode,
              Status = x.IsActive ? "Active" : "Inactive"
           }).ToList());
        }
    }
}
