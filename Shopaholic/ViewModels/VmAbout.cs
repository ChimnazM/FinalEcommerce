using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmAbout : VmBase
    {
        public About About { get; set; }
        public List<ChooseUs> ChooseUs { get; set; }
        public List<MissionFeature> MissionFeatures { get; set; }
        public MissionFile MissionFile { get; set; }
        public Testimonial Testimonial { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Partner> Partners { get; set; }
    }
}
