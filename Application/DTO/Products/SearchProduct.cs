using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Products
{
    public class SearchProduct : PagedSearch
    {
        public string Keyword { get; set; }
        public string CategoryId { get; set; }
        public List<int?> BrandIds { get; set; }
        public List<int?> ColorIds { get; set; }
        public List<int?> SizeIds { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Sort { get; set; }
        public bool? IsActive { get; set; }
    }
}
