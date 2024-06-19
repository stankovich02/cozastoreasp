using Application.DTO.UsersBillingAddresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UsersBillingAddresses
{
    public interface IGetUserBillingAddressQuery : IQuery<UserBillingAddressDTO, int>
    {
    }
}
