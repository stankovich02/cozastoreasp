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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
           builder.Property(x => x.Quantity).IsRequired();

           builder.Property(x => x.Price).IsRequired();

           builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);

           builder.HasOne(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

           builder.HasIndex(x => x.Price);
        }
    }
}
