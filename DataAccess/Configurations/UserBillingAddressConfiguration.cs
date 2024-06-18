using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserBillingAddressConfiguration : EntityConfiguration<UserBillingAddress>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserBillingAddress> builder)
        {
            builder.Property(x => x.Phone)
                   .IsRequired()
                   .HasMaxLength(20); 
            
            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(40);

            builder.Property(x => x.Country)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.City)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.ZipCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(x => x.Country);

            builder.HasIndex(x => x.City);

            builder.HasOne(x => x.User).WithMany(x => x.BillingAddresses).HasForeignKey(x => x.UserId);
        }
    }
}
