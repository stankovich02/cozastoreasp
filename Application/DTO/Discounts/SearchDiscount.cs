using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Discounts
{
    public class SearchDiscount : PagedSearch
    {
        public int? ProductId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? IsActive { get; set; }
    }
}
