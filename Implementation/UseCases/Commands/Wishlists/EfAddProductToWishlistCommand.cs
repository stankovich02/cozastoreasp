using Application;
using Application.DTO.Wishlists;
using Application.Exceptions;
using Application.UseCases.Commands.Wishlists;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Wishlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Wishlists
{
    public class EfAddProductToWishlistCommand : EfUseCase, IAddProductToWishlistCommand
    {
        private readonly AddProductToWishlistValidator _validator;
        private readonly IApplicationActor _actor;

        public EfAddProductToWishlistCommand(CozaStoreContext context, AddProductToWishlistValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 56;

        public string Name => "Add Product to Wishlist";

        public string Table => "Wishlists";

        public void Execute(AddProductToWishlistDTO data)
        {
            _validator.ValidateAndThrow(data);

            bool productExistInWishlist = Context.Wishlists.Any(x => x.UserId == _actor.Id && x.ProductId == data.ProductId);
            if (productExistInWishlist)
            {
                throw new ConflictException("Product is already in your wishlist.");
            }

            Context.Wishlists.Add(new Wishlist
            {
                ProductId = data.ProductId,
                UserId = _actor.Id
            });

            Context.SaveChanges();
        }
    }
}
