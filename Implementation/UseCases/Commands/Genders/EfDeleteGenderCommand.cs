using Application.Exceptions;
using Application.UseCases.Commands.Genders;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Genders
{
    public class EfDeleteGenderCommand : EfUseCase,IDeleteGenderCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteGenderCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 18;

        public string Name => "Delete Gender";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Gender>(data, "Gender");
        }
    }
}
