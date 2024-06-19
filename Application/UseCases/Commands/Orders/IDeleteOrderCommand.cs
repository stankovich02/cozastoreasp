using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Orders
{
    public interface IDeleteOrderCommand : ICommand<int>
    {
    }
}
