using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Users
{
    public class UpdateUserAccessDTO
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
