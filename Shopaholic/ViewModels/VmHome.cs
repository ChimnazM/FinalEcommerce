using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmHome : VmBase
    {
        public List<Partner> Partners { get; set; }
        public Testimonial Testimonial { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Advertisement> Advertisements { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<AllInfoToProduct> AllInfoToProducts { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
