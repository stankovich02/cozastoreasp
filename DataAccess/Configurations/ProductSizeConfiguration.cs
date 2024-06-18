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
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.Sizes).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Size).WithMany(x => x.Products).HasForeignKey(x => x.SizeId);

            builder.HasKey(x => new { x.ProductId, x.SizeId });
        }
    }
}
