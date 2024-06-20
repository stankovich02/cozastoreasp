using Application;
using Application.Exceptions;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase,IDeleteUserCommand
    {

        public EfDeleteUserCommand(CozaStoreContext context)
            : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Removing User";

        public string Table => "Users";

        public void Execute(int data)
        {
            User u = Context.Users.Find(data);

            if(u == null)
            {
                throw new EntityNotFoundException();
            }

            u.IsActive = false;

            Context.SaveChanges();
        }
    }
}
