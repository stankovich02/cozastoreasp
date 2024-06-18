using Application.Exceptions;
using Application.UseCases.Commands.Colors;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Colors
{
    public class EfDeleteColorCommand : EfUseCase, IDeleteColorCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteColorCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 15;

        public string Name => "Delete Color";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Color>(data, "Color");
        }
    }
}
