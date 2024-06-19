using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reviews
{
    public class SearchReview : PagedSearch
    {
        public int? ProductId { get; set; }
        public int? Rate { get; set; }
        public int? UserId { get; set; }
        public DateTime? ReviewedAtFrom { get; set; }
        public DateTime? ReviewedAtTo { get; set; }
    }
}
