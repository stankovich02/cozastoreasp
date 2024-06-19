using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UsersBillingAddresses
{
    public class UserBillingAddressDTO
    {
        public string User { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Status { get; set; }
    }
}
