using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmTestimonial
    {
        public Testimonial Testimonial { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
