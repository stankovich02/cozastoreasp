using Application.DTO.Discounts;
using Application.UseCases.Commands.Discounts;
using DataAccess;
using Domain;
using Implementation.Validators.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Discounts
{
    public class EfCreateDiscountCommand : EfUseCase,ICreateDiscountCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateDiscountValidator _validator;

        public EfCreateDiscountCommand(GenericCreateService genericCreateService, CreateDiscountValidator validator,CozaStoreContext context)
            : base(context)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Create Discount";

        public string Table => "Discounts";

        public void Execute(CreateDiscountDTO data)
        {
            Discount oldDiscount = Context.Discounts.FirstOrDefault(d => d.ProductId == data.ProductId && d.IsActive);
            if (oldDiscount != null)
            {
                oldDiscount.IsActive = false;
            }
            Context.SaveChanges();
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Discount
                {
                    ProductId = data.ProductId,
                    DiscountPercent = data.DiscountPercent,
                    DateFrom = data.DateFrom,
                    DateTo = data.DateTo,
                };
            });
        }
    }
}
