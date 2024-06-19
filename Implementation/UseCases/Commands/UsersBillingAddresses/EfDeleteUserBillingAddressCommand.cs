using Application.UseCases.Commands.UsersBillingAddresses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UsersBillingAddresses
{
    public class EfDeleteUserBillingAddressCommand : IDeleteUserBillingAddressCommand
    {
        private readonly GenericDeleteService _genericDeleteService;

        public EfDeleteUserBillingAddressCommand(GenericDeleteService genericDeleteService)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 43;

        public string Name => "Delete User billing address";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<UserBillingAddress>(data, "User Billing Address");
        }
    }
}
