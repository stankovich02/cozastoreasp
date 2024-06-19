using Application.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Messages
{
    public interface IGetMessageQuery : IQuery<MessageDTO, int>
    {
    }
}
