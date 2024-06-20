using Application.DTO;
using Application.DTO.AuditLogs;
using Application.DTO.Users;
using Application.UseCases.Queries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.AuditLogs
{
    internal class EfGetAuditLogsQuery : EfUseCase,IGetAuditLogsQuery
    {
        private readonly GenericPagedResponse _response;

        public EfGetAuditLogsQuery(GenericPagedResponse response, CozaStoreContext context)
            : base(context)
        {
            _response = response;
        }

        public int Id => 73;

        public string Name => "Search Audit Logs";

        public string Table => "Audit logs";

        public PagedResponse<AuditLogDTO> Execute(SearchAuditLog search)
        {
            return _response.ReturnPagedResponse<AuditLog, AuditLogDTO, SearchAuditLog>(search, Context, (query, search) =>
            {
                if (!string.IsNullOrEmpty(search.Username))
                {
                    query = query.Where(x => x.PerformedBy.ToLower().Contains(search.Username.ToLower()));
                }
                if (!string.IsNullOrEmpty(search.Action))
                {
                    query = query.Where(x => x.Action.ToLower().Contains(search.Action.ToLower()));
                }
                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.ExecutedAt >= search.DateFrom);
                }
                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.ExecutedAt <= search.DateTo);
                }
                return query;
            },
           query => query.Select(x => new AuditLogDTO
           {
               Id = x.Id,
               Action = x.Action,
               PerformedBy = x.PerformedBy,
               Data = x.Data,
               ExecutedAt = x.ExecutedAt
           }).ToList());
        }
    }
}
