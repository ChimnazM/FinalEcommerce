using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmProduct
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<AllInfoToProduct> AllInfoToProducts { get; set; }

    }
}
