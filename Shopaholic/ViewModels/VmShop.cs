using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmShop : VmBase
    {
        public List<Product> Products { get; set; }
        public List<Product> AllProducts { get; set; }
        public Product Product { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Category> Categories { get; set; }
        public List<Advertisement> Advertisements { get; set; }
        public List<AllInfoToProduct> AllInfoToProducts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }

        public int? catId { get; set; }
        public int? genId { get; set; }
        public int? sizeId { get; set; }
        public int? colorId { get; set; }
        public int? SortId { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public VmShop Filter { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<AllInfoToProduct> FeaturedAllInfoToProducts { get; set; }
        public List<Comment> FeaturedComments { get; set; }
        public List<ProductImage> FeaturedProductImages { get; set; }
    }
}
