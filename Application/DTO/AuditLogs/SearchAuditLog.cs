using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.AuditLogs
{
    public class SearchAuditLog : PagedSearch
    {
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
