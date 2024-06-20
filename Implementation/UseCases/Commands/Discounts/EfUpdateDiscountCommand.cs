using Application.DTO.Discounts;
using Application.DTO.PaymentTypes;
using Application.UseCases.Commands.Discounts;
using Domain;
using Implementation.Validators.Discounts;
using Implementation.Validators.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Discounts
{
    public class EfUpdateDiscountCommand : IUpdateDiscountCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateDiscountValidator _validator;

        public EfUpdateDiscountCommand(GenericUpdateService genericUpdateService, UpdateDiscountValidator validator)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "Update Discount";

        public string Table => "Discounts";

        public void Execute(UpdateDiscountDTO data)
        {
            _genericUpdateService.UpdateEntity<Discount, UpdateDiscountDTO, UpdateDiscountValidator>(data, _validator,
                (entity, dto) =>
                {
                    entity.ProductId = dto.ProductId;
                    entity.DateFrom = dto.DateFrom;
                    entity.DateTo = dto.DateTo;
                    entity.DiscountPercent = dto.DiscountPercent;
                });
        }
    }
}
