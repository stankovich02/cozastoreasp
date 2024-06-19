using Application.DTO;
using Application.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Orders
{
    public interface IGetOrdersQuery : IQuery<PagedResponse<OrderDTO>,SearchOrder>
    {
    }
}
