using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reviews
{
    public class CreateReviewDTO
    {
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }
    }
}
