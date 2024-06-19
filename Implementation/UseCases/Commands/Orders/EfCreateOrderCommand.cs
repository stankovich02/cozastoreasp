using Application;
using Application.DTO.Orders;
using Application.UseCases.Commands.Orders;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators.Orders;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Orders
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateOrderCommand(CozaStoreContext context, CreateOrderValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 49;

        public string Name => "Create Order";

        public void Execute(CreateOrderDTO data)
        {
            _validator.ValidateAndThrow(data);

            decimal TotalPrice = 0;
            var productsPrices = Context.Products
                                        .Where(x => data.Products
                                        .Select(x => x.ProductId).Contains(x.Id))
                                        .Select(x => x.Prices.Where(x => x.DateFrom <= DateTime.Now && x.DateTo == null && x.IsActive)
                                        .Select(x => new ProductWithCurrentPriceDTO
                                        {
                                            ProductId = x.Product.Id,
                                            Price = x.ProductPrice
                                        })).ToList();

            foreach (var product in data.Products)
            {
                var productPrice = productsPrices.Where(x => x.Select(x => x.ProductId).Contains(product.ProductId)).Select(x => x.Select(x => x.Price)).FirstOrDefault().FirstOrDefault();
                int discount = Context.Discounts.Where(x => x.DateFrom <= DateTime.Now && x.DateTo > DateTime.Now && x.IsActive && x.ProductId == product.ProductId).Select(x=> x.DiscountPercent).FirstOrDefault();
                bool hasDiscount = discount > 0;
                decimal productPriceWithDiscount = hasDiscount ? productPrice - (productPrice * discount / 100) : productPrice;

                TotalPrice += productPriceWithDiscount * product.Quantity;
            }
            Order order = new()
            {
                OrderedAt = DateTime.UtcNow,
                PaymentTypeId = data.PaymentTypeId,
                TotalPrice = TotalPrice,
                UserId = _actor.Id,
                OrderItems = data.Products.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = productsPrices.Where(y => y.Select(y => y.ProductId).Contains(x.ProductId)).Select(y => y.Select(y => y.Price)).FirstOrDefault().FirstOrDefault()
                }).ToList()
            };
            
            Context.Orders.Add(order);

            Context.SaveChanges();
        }
    }
}
