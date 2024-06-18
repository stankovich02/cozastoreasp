using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.Password)
                   .IsRequired();

            builder.HasIndex(x => x.Email)
                   .IsUnique();
            
            builder.HasIndex(x => x.Username)
                   .IsUnique();

            builder.HasIndex(x => new
            {
                x.Username,
                x.FirstName,
                x.LastName,
                x.Email,
            });

            builder.HasOne(x => x.Image).WithMany(x => x.Users).HasForeignKey(x => x.ImageId);
        }
    }
}
