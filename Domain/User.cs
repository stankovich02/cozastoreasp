using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ImageId { get; set; }


        public virtual Image Image { get; set; }
        public virtual ICollection<Cart> CartProducts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<Wishlist> WishlistProducts { get; set; } = new HashSet<Wishlist>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<UserBillingAddress> BillingAddresses { get; set; } = new HashSet<UserBillingAddress>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();
    }
}
