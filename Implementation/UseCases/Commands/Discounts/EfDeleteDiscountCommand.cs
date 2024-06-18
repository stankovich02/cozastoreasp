using Application.UseCases.Commands.Discounts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Discounts
{
    public class EfDeleteDiscountCommand : IDeleteDiscountCommand
    {
        private readonly GenericDeleteService _genericDeleteService;

        public EfDeleteDiscountCommand(GenericDeleteService genericDeleteService)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 36;

        public string Name => "Delete Discount";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Discount>(data, "Discount");
        }
    }
}
