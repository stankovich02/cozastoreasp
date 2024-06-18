using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Products
{
    public class UpdateProductDTO : UpdateEntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public int Available { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<int> Sizes { get; set; }
        public IEnumerable<int> Colors { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
