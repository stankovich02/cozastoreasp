using Application.DTO.PaymentTypes;
using Application.DTO.Reviews;
using Application.UseCases.Commands.Reviews;
using Domain;
using Implementation.Validators.PaymentTypes;
using Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Reviews
{
    public class EfUpdateReviewCommand : IUpdateReviewCommand
    {
        private readonly GenericUpdateService _genericUpdateService;
        private readonly UpdateReviewValidator _validator;

        public EfUpdateReviewCommand(GenericUpdateService genericUpdateService, UpdateReviewValidator validator)
        {
            _genericUpdateService = genericUpdateService;
            _validator = validator;
        }

        public int Id => 54;

        public string Name => "Update Review";

        public void Execute(UpdateReviewDTO data)
        {
            _genericUpdateService.UpdateEntity<Review, UpdateReviewDTO, UpdateReviewValidator>(data, _validator,
              (entity, dto) =>
              {
                  entity.Rate = dto.Rate;
                  entity.ReviewText = dto.ReviewText;
              });
        }
    }
}
