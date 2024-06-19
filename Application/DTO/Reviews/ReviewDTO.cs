using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reviews
{
    public class ReviewDTO
    {
        public string Product { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }
        public string User { get; set; }
        public DateTime ReviewedAt { get; set; }
        public string Status { get; set; }
    }
}
