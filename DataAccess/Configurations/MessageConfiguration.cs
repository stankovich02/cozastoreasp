using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(50); 
            
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.Property(x => x.Subject)
                   .IsRequired()
                   .HasMaxLength(30);
            
            builder.Property(x => x.MessageText)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.SendedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
