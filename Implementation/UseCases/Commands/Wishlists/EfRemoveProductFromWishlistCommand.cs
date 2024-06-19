using Application;
using Application.Exceptions;
using Application.UseCases.Commands.Wishlists;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Wishlists
{
    public class EfRemoveProductFromWishlistCommand : EfUseCase,IRemoveProductFromWishlistCommand
    {
        private readonly IApplicationActor _actor;

        public EfRemoveProductFromWishlistCommand(CozaStoreContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 57;

        public string Name => "Remove Product from Wishlist";

        public void Execute(int data)
        {
            bool productExist = Context.Products.Any(x => x.Id == data && x.IsActive);

            if (!productExist)
            {
                throw new EntityNotFoundException();
            }

            Wishlist productInWishlist = Context.Wishlists.Where(x => x.ProductId == data && x.UserId == _actor.Id).FirstOrDefault();

            if (productInWishlist == null)
            { 
                throw new ConflictException("You don't have this product in your wishlist.");
            }

            Context.Wishlists.Remove(productInWishlist);

            Context.SaveChanges();
        }
    }
}
