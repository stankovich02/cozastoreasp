using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : NamedEntityConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Available).IsRequired();



            builder.HasOne(x => x.Category).WithMany(x => x.Products).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gender).WithMany(x => x.Products).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand).WithMany(x => x.Products).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
