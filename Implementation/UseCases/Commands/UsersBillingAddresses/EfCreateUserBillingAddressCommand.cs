using Application;
using Application.DTO.UsersBillingAddresses;
using Application.UseCases.Commands.UsersBillingAddresses;
using Domain;
using Implementation.Validators.UsersBillingAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.UsersBillingAddresses
{
    public class EfCreateUserBillingAddressCommand : ICreateUserBillingAddressCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateUserBillingAddressValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateUserBillingAddressCommand(GenericCreateService genericCreateService, CreateUserBillingAddressValidator validator, IApplicationActor actor)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 41;

        public string Name => "Create User billing address";

        public string Table => "User billing addresses";

        public void Execute(CreateUserBillingAddressDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new UserBillingAddress
                {
                    UserId = _actor.Id,
                    Address = data.Address,
                    City = data.City,
                    Country = data.Country,
                    Phone = data.Phone,
                    ZipCode = data.ZipCode  
                };
            });
        }
    }
}
