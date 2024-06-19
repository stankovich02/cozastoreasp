using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reviews
{
    public class UpdateReviewDTO : UpdateEntityDTO
    {
        public string ReviewText { get; set; }
        public int Rate { get; set; }
    }
}
