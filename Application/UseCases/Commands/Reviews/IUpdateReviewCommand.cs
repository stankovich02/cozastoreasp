using Application.DTO.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Reviews
{
    public interface IUpdateReviewCommand : ICommand<UpdateReviewDTO>
    {
    }
}
