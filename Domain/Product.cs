using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : NamedEntity
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public int Available {  get; set; }



        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<ProductSize> Sizes { get; set; } = new HashSet<ProductSize>();
        public virtual ICollection<ProductColor> Colors { get; set; } = new HashSet<ProductColor>();
        public virtual ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>(); 
        public virtual ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>(); 
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>(); 
        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new HashSet<Wishlist>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<OrderItem> Orders { get; set; } = new HashSet<OrderItem>();

    }
}
