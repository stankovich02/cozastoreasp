using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Wishlists
{
    public class SearchWishlist : PagedSearch
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
    }
}
