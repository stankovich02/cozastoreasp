using Application;
using Application.DTO.Users;
using Application.Exceptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserImageCommand : EfUseCase,IUpdateUserImageCommand
    {
        private readonly UpdateUserImageValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateUserImageCommand(UpdateUserImageValidator validator, IApplicationActor actor, CozaStoreContext context)
            : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "User image update";

        public string Table => "Users";

        public void Execute(UpdateUserImageDTO data)
        {
            User u = Context.Users.Find(_actor.Id);

            if(u == null)
            {
                throw new EntityNotFoundException();
            }

            _validator.ValidateAndThrow(data);


            var tempFile = Path.Combine("wwwroot", "temp", data.File);
            var destinationFile = Path.Combine("wwwroot", "images", "users", data.File);
            File.Move(tempFile, destinationFile);

            u.Image = new Image { Path = $"/images/users/{data.File}" };

            Context.SaveChanges();
        }
    }
}
