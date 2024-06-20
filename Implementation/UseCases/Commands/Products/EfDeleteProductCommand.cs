using Application.Exceptions;
using Application.UseCases.Commands.Products;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Products
{
    public class EfDeleteProductCommand : EfUseCase,IDeleteProductCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteProductCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 31;

        public string Name => "Delete Product";

        public string Table => "Products";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Product>(data, "Product");
        }
    }
}
