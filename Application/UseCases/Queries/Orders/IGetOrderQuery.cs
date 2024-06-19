using Application.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Orders
{
    public interface IGetOrderQuery : IQuery<OrderDTO, int>
    {
    }
}
