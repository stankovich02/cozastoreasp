using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly CozaStoreContext _context;

        protected EfUseCase(CozaStoreContext context)
        {
            _context = context;
        }
        protected CozaStoreContext Context => _context;
    }
}
