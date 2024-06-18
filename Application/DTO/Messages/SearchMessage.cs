using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Messages
{
    public class SearchMessage : PagedSearch
    {
        public DateTime? SendedAtFrom { get; set; }
        public DateTime? SendedAtTo { get; set; }
    }
}
