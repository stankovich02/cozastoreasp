using Application;
using DataAccess;
using Domain;
using Implementation.UseCases;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Implementation.Logging.UseCases
{
    public class EfUseCaseLogger : EfUseCase, IUseCaseLogger
    {
        public EfUseCaseLogger(CozaStoreContext context) : base(context)
        {
        }

        public void Log(UseCaseLog log)
        {
            Context.AuditLogs.Add(new AuditLog
            {
                Action = log.UseCaseName,
                PerformedBy = log.Username,
                Data = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            });
            Context.SaveChanges();
        }
    }
}
