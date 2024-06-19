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
                        new() { UseCaseId = 5 },
                        new() { UseCaseId = 9 },
                        new() { UseCaseId = 13 },
                        new() { UseCaseId = 25 },
                        new() { UseCaseId = 26 },
                        new() { UseCaseId = 27 },
                        new() { UseCaseId = 28 },
                        new() { UseCaseId = 29 },
                        new() { UseCaseId = 33 },
                        new() { UseCaseId = 38 },
                        new() { UseCaseId = 41 },
                        new() { UseCaseId = 42 },
                        new() { UseCaseId = 43 },
                        new() { UseCaseId = 45 },
                        new() { UseCaseId = 46 },
                        new() { UseCaseId = 47 },
                        new() { UseCaseId = 49 },
                        new() { UseCaseId = 51 },
                        new() { UseCaseId = 52 },
                        new() { UseCaseId = 53 },
                        new() { UseCaseId = 54 },
                        new() { UseCaseId = 56 },
                        new() { UseCaseId = 57 },
                    }
                };
            });
        }
    }
}
