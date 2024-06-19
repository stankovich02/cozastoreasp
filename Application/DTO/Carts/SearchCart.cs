using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Carts
{
    public class SearchCart : PagedSearch
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
