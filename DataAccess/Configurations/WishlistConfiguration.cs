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
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.WishlistProducts).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product).WithMany(x => x.Wishlists).HasForeignKey(x => x.ProductId);

            builder.HasKey(x => new { x.UserId, x.ProductId });
        }
    }
}
