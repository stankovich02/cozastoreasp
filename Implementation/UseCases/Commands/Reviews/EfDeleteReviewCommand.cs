using Application.UseCases.Commands.Reviews;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Reviews
{
    public class EfDeleteReviewCommand : IDeleteReviewCommand
    {
        private readonly GenericDeleteService _genericDeleteService;

        public EfDeleteReviewCommand(GenericDeleteService genericDeleteService)
        {
            _genericDeleteService = genericDeleteService;
        }

        public int Id => 53;

        public string Name => "Delete Review";

        public string Table => "Reviews";

        public void Execute(int data)
        {
            _genericDeleteService.DeactivateEntity<Review>(data, "Review");
        }
    }
}
