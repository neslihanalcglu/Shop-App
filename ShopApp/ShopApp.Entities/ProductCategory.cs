using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ProductCategory
    {
        //public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } //Navigation Property

        public int ProductId { get; set; }
        public Product Product { get; set; }

        // public List<Product> Products { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
