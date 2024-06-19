using Application.DTO.Messages;
using Application.UseCases.Queries.Messages;
using Azure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Messages
{
    public class EfGetMessageQuery : IGetMessageQuery
    {
        private readonly GenericSingleResponse _response;

        public EfGetMessageQuery(GenericSingleResponse response)
        {
            _response = response;
        }

        public int Id => 65;

        public string Name => "Get single Message";

        public MessageDTO Execute(int search)
        {
            return _response.ReturnSingle<Message, MessageDTO>(search, entity => new MessageDTO
            {
                Id = entity.Id,
                Email = entity.Email,
                FullName = entity.FullName,
                MessageText = entity.MessageText,
                SendedAt = entity.SendedAt,
                Subject = entity.Subject
            });
        }
    }
}
