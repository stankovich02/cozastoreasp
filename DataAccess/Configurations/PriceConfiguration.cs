using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PriceConfiguration : EntityConfiguration<Price>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.DateFrom).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.Prices);

            builder.HasIndex(x => new { x.ProductPrice, x.DateFrom, x.DateTo });
        }
    }
}
