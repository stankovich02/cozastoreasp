using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Orders
{
    public class SearchOrder : PagedSearch
    {
        public int? UserId { get; set; }
        public int? PaymentTypeId { get; set; }
        public DateTime? OrderedAtFrom { get; set; }
        public DateTime? OrderedAtTo { get; set; }
        public int? ProductId { get; set; }
    }
}
