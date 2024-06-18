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
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.Colors).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Color).WithMany(x => x.Products).HasForeignKey(x => x.ColorId);

            builder.HasKey(x => new { x.ProductId, x.ColorId });
        }
    }
}
