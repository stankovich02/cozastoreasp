using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0; 
        public string FirstName => "unauthorized";
        public string LastName => "unauthorized";
        public string Username => "unauthorized";
        public string Email => "unauthorized";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 9, 13, 25, 26, 27, 28, 29, 33, 38 };
    }
}
