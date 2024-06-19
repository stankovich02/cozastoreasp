using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UsersBillingAddresses
{
    public class UpdateUserBillingAddressDTO : UpdateEntityDTO
    {
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
