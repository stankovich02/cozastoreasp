using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class DiscountConfiguration : EntityConfiguration<Discount>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(x => x.DiscountPercent).IsRequired();

            builder.Property(x => x.DateFrom).IsRequired();

            builder.Property(x => x.DateTo).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.Discounts);

            builder.HasIndex(x => new {x.DiscountPercent,x.DateFrom,x.DateTo});
        }
    }
}
