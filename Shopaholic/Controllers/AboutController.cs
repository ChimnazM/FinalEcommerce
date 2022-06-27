using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopwise.Data;
using Shopwise.ViewModels;

namespace Shopwise.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            VmAbout model = new VmAbout()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                About = _context.About.FirstOrDefault(),
                ChooseUs = _context.ChooseUs.ToList(),
                MissionFeatures = _context.MissionFeatures.ToList(),
                MissionFile = _context.MissionFiles.FirstOrDefault(),
                Testimonial = _context.Testimonial.FirstOrDefault(),
                Feedbacks = _context.Feedbacks.ToList(),
                Partners = _context.Partners.ToList()
            };

            return View(model);
        }
    }
}
