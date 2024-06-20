﻿using Application.DTO;
using Application.DTO.AuditLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries
{
    public interface IGetAuditLogsQuery : IQuery<PagedResponse<AuditLogDTO>,SearchAuditLog>
    {
    }
}
