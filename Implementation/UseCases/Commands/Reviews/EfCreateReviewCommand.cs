using Application;
using Application.DTO.Reviews;
using Application.UseCases.Commands.Reviews;
using Domain;
using Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Reviews
{
    public class EfCreateReviewCommand : ICreateReviewCommand
    {
        private readonly GenericCreateService _genericCreateService;
        private readonly CreateReviewValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateReviewCommand(GenericCreateService genericCreateService, CreateReviewValidator validator, IApplicationActor actor)
        {
            _genericCreateService = genericCreateService;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 52;

        public string Name => "Create Review";

        public void Execute(CreateReviewDTO data)
        {
            _genericCreateService.CreateEntity(data, _validator, (data) =>
            {
                return new Review
                {
                    ProductId = data.ProductId,
                    Rate = data.Rate,
                    ReviewText = data.ReviewText,
                    UserId = _actor.Id
                };
            });
        }
    }
}
