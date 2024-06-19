using Application.DTO.UsersBillingAddresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.UsersBillingAddresses
{
    public interface ICreateUserBillingAddressCommand : ICommand<CreateUserBillingAddressDTO>
    {
    }
}
