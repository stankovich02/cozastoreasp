using Application.Exceptions;
using Application.UseCases.Commands.Orders;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Orders
{
    public class EfDeleteOrderCommand : EfUseCase,IDeleteOrderCommand
    {
        public EfDeleteOrderCommand(CozaStoreContext context) : base(context)
        {
        }

        public int Id => 50;
        public string Name => "Delete Order";

        public string Table => "Orders";

        public void Execute(int data)
        {
            var entity = Context.Orders.Find(data);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            Context.Orders.Remove(entity);

            Context.SaveChanges();
        }
    }
}
