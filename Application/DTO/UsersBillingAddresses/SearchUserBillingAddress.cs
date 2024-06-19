using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UsersBillingAddresses
{
    public class SearchUserBillingAddress : PagedSearch
    {
        public int? UserId { get; set; }
        public string ZipCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
