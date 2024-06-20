using Application;
using Application.DTO.UsersBillingAddresses;
using Application.Exceptions;
using Application.UseCases.Commands.UsersBillingAddresses;
using Domain;
using Implementation.Validators.UsersBillingAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UsersBillingAddresses
{
    public class EfUpdateUserBillingAddressCommand : IUpdateUserBillingAddressCommand
    {
        private readonly IApplicationActor _actor;
        private readonly UpdateUserBillingAddressValidator _validator;
        private readonly GenericUpdateService _genericUpdateService;

        public EfUpdateUserBillingAddressCommand(IApplicationActor actor, UpdateUserBillingAddressValidator validator, GenericUpdateService genericUpdateService)
        {
            _actor = actor;
            _validator = validator;
            _genericUpdateService = genericUpdateService;
        }

        public int Id => 42;

        public string Name => "Update User billing address";

        public string Table => "User billing addresses";

        public void Execute(UpdateUserBillingAddressDTO data)
        {
            _genericUpdateService.UpdateEntity<UserBillingAddress, UpdateUserBillingAddressDTO, UpdateUserBillingAddressValidator>(data, _validator,
               (entity, dto) =>
               {
                entity.Address = data.Address;
                entity.City = data.City;
                entity.Country = data.Country;
                entity.Phone = data.Phone;
                entity.ZipCode = data.ZipCode;
               });
        }
    }
}
