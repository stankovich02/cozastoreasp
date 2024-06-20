using Application;
using Application.Exceptions;
using Application.UseCases.Commands.Carts;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Carts
{
    public class EfRemoveProductFromCartCommand : EfUseCase,IRemoveProductFromCartCommand
    {
        private readonly IApplicationActor _actor;

        public EfRemoveProductFromCartCommand(IApplicationActor actor,CozaStoreContext context)
         : base(context)
        {
            _actor = actor;
        }

        public int Id => 47;

        public string Name => "Delete Product from Cart";
        public string Table => "Carts";

        public void Execute(int data)
        {
           bool productExist = Context.Products.Any(x => x.Id == data && x.IsActive);

            if (!productExist)
            {
                throw new EntityNotFoundException();
            }

            Cart productInCart = Context.Carts.Where(x => x.ProductId == data && x.UserId == _actor.Id).FirstOrDefault();

            if (productInCart == null)
            {
                throw new ConflictException("You don't have this product in your cart.");
            }

            Context.Carts.Remove(productInCart);

            Context.SaveChanges();
        }
    }
}
