using Application;
using Application.DTO.Carts;
using Application.Exceptions;
using Application.UseCases.Commands.Carts;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Carts
{
    public class EfAddProductToCartCommand : EfUseCase,ICreateCartCommand
    {
        private readonly CreateCartValidator _validator;
        private readonly IApplicationActor _actor;
        public EfAddProductToCartCommand(CozaStoreContext context, CreateCartValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 45;

        public string Name => "Add Product to Cart";

        public void Execute(AddProductToCartDTO data)
        {
            _validator.ValidateAndThrow(data);

            bool productExistInCart = Context.Carts.Any(x => x.UserId == _actor.Id && x.ProductId == data.ProductId);
            if (productExistInCart) {
                throw new ConflictException("Product is already in your cart.");
            }

            Context.Carts.Add(new Cart
            {
                ProductId = data.ProductId,
                Quantity = data.Quantity,
                UserId = _actor.Id
            });

            Context.SaveChanges();
        }
    }
}
