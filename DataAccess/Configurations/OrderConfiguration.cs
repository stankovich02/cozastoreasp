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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.TotalPrice).IsRequired();

            builder.Property(x => x.OrderedAt).IsRequired();

            builder.HasOne(x => x.PaymentType).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

            builder.HasIndex(x => x.TotalPrice);
        }
    }
}
