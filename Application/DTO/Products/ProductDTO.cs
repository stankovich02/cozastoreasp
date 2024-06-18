using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public ProductPriceDTO Price { get; set; }
        public int? Discount { get; set; } = null;
        public List<string> Sizes { get; set; }
        public List<string> Colors { get; set; }
        public bool InStock { get; set; }
        public List<string> Images { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
        public decimal AverageRating { get; set; }

    }
    public class ProductPriceDTO
    {
        public decimal? OldPrice { get; set; }
        public decimal ActivePrice { get; set; }
    }
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public string Avatar { get; set; }
        public DateTime CommentedAt { get; set; }
    }
}
