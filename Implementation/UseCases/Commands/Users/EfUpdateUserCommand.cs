using Application;
using Application.DTO.Sizes;
using Application.DTO.Users;
using Application.Exceptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Sizes;
using Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase,IUpdateUserCommand
    {
        private readonly UpdateUserDtoValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly GenericUpdateService _genericUpdateService;
        public EfUpdateUserCommand(UpdateUserDtoValidator validator, CozaStoreContext context, IApplicationActor actor, GenericUpdateService genericUpdateService)
            : base(context)
        {
            _validator = validator;
            _actor = actor;
            _genericUpdateService = genericUpdateService;
        }

        public int Id => 3;

        public string Name => "User update";

        public void Execute(UpdateUserDTO data)
        {
            if(data.Id != _actor.Id)
            {
                throw new ConflictException("You cannot update other user info.");
            }

            _genericUpdateService.UpdateEntity<User, UpdateUserDTO, UpdateUserDtoValidator>(data, _validator,
               (entity, dto) =>
               {
                   entity.FirstName = data.FirstName;
                   entity.LastName = data.LastName;
                   entity.Email = data.Email;
                   entity.Username = data.Username;
               });
        }
    }
}
