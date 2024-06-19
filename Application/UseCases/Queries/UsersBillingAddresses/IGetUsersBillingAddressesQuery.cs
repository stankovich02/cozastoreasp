using Application.DTO;
using Application.DTO.UsersBillingAddresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UsersBillingAddresses
{
    public interface IGetUsersBillingAddressesQuery :IQuery<PagedResponse<UserBillingAddressDTO>,SearchUserBillingAddress>
    {
    }
}
