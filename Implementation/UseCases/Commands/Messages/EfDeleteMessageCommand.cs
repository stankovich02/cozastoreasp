using Application.Exceptions;
using Application.UseCases.Commands.Messages;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Messages
{
    public class EfDeleteMessageCommand : EfUseCase, IDeleteMessageCommand
    {
        public EfDeleteMessageCommand(CozaStoreContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "Delete Message";

        public string Table => "Messages";

        public void Execute(int data)
        {
            var message = Context.Messages.Find(data);

            if (message == null)
            {
                throw new EntityNotFoundException();
            }

            Context.Messages.Remove(message);   

            Context.SaveChanges();
        }
    }
}
