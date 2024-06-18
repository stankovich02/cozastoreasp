using Application.DTO.Users;
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
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly RegisterUserDtoValidator _validator;

        public EfRegisterUserCommand(RegisterUserDtoValidator validator, CozaStoreContext context, GenericCreateService genericCreateService)
            : base(context)
        {
            _validator = validator;
            _genericCreateService = genericCreateService;
        }

        public int Id => 1;

        public string Name => "User registration";

        public void Execute(RegisterUserDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new User
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    Username = data.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(data.Password + "CozaStore"),
                    Image = Context.Images.FirstOrDefault(x => x.Path.Contains("default")),
                    UseCases = new List<UserUseCase>()
                    {
                        new() { UseCaseId = 3 },
                        new() { UseCaseId = 5 }
                    }
                };
            });
        }
    }
}
