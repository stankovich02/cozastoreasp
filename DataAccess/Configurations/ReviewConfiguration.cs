using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ReviewConfiguration : EntityConfiguration<Review>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Rate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product).WithMany(x => x.Reviews).HasForeignKey(x => x.ProductId);

            builder.HasIndex(x => x.Rate);
        }
    }
}
