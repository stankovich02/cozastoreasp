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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Carts
{
    public class EfUpdateProductInCartCommand : EfUseCase,IUpdateProductInCartCommand
    {
        private readonly UpdateProductInCartValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateProductInCartCommand(CozaStoreContext context, UpdateProductInCartValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 46;
        public string Name => "Update Product in Cart";

        public void Execute(UpdateProductInCartDTO data)
        {
            _validator.ValidateAndThrow(data);

            Cart productInCart = Context.Carts.Where(x => x.ProductId == data.ProductId && x.UserId == _actor.Id).FirstOrDefault();

            if (productInCart == null)
            {
                throw new EntityNotFoundException();
            }

           

            productInCart.Quantity = data.Quantity;

            Context.SaveChanges();
        }
    }
}
