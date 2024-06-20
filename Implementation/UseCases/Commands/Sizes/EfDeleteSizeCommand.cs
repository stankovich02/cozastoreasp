using Application.Exceptions;
using Application.UseCases.Commands.Sizes;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Sizes
{
    public class EfDeleteSizeCommand : EfUseCase,IDeleteSizeCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteSizeCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 24;

        public string Name => "Delete Size";

        public string Table => "Sizes";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Size>(data, "Size");
        }
    }
}
