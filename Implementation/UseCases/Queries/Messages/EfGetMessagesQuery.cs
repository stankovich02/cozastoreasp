using Application.DTO;
using Application.DTO.Genders;
using Application.DTO.Messages;
using Application.UseCases.Queries.Messages;
using Azure;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Messages
{
    public class EfGetMessagesQuery : EfUseCase,IGetMessagesQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetMessagesQuery(GenericPagedResponse response, CozaStoreContext context)
            : base(context)
        {
            _response = response;
        }

        public int Id => 40;

        public string Name => "Search Messages";

        public PagedResponse<MessageDTO> Execute(SearchMessage search)
        {
            return _response.ReturnPagedResponse<Message, MessageDTO, SearchMessage>(search, Context, (query, search) =>
            {
                if (search.SendedAtFrom.HasValue)
                {
                    query = query.Where(x => x.SendedAt >= search.SendedAtFrom);
                }
                if (search.SendedAtTo.HasValue)
                {
                    query = query.Where(x => x.SendedAt <= search.SendedAtTo);
                }
                return query;
            },
           query => query.Select(x => new MessageDTO
           {
               Id = x.Id,
               Email = x.Email,
               FullName = x.FullName,
               MessageText = x.MessageText,
               SendedAt = x.SendedAt,
               Subject = x.Subject
           }).ToList());
        }
    }
}
