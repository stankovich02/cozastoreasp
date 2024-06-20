using Application.Exceptions;
using Application.UseCases.Commands.Categories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfUseCase,IDeleteCategoryCommand
    {
        private readonly GenericDeleteService _genericDeleteService;
        public EfDeleteCategoryCommand(CozaStoreContext context, GenericDeleteService genericDeleteService) : base(context)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 8;

        public string Name => "Delete category";

        public string Table => "Categories";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Category>(data,"Category"); 
        }
    }
}
