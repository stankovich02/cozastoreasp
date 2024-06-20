using Application.Exceptions;
using Application.UseCases.Commands.Brands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Brands
{
    public class EfDeleteBrandCommand : EfUseCase,IDeleteBrandCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteBrandCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 12;

        public string Name => "Delete Brand";
        public string Table => "Brands";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Brand>(data, "Brand");
        }
    }
}
