﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.Property(x => x.Message)
                   .IsRequired();

            builder.Property(x => x.StackTrace)
                   .IsRequired();

            builder.HasKey(x => x.ErrorId);

            builder.Property(x => x.Time).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(x => x.Time);
        }
    }
}
