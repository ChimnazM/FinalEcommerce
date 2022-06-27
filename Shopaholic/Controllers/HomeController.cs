using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> Categories = _context.Categories.ToList();

            VmHome model = new VmHome()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                Partners = _context.Partners.ToList(),
                Testimonial = _context.Testimonial.FirstOrDefault(),
                Feedbacks = _context.Feedbacks.ToList(),
                Advertisements = _context.Advertisements.ToList(),
                Sliders = _context.Sliders.ToList(),
                Products = _context.Products.Include(c=>c.Category).Include(p=>p.ProductImages).Include(s=>s.AllInfoToProducts).ToList(),
                Categories = _context.Categories.ToList(),
                Comments = _context.Comments.ToList(),
                ProductImages = _context.ProductImages.ToList(),
                AllInfoToProducts = _context.AllInfoToProducts.ToList(),
                

            };
            

            return View(model);
        }

        public IActionResult ErrorPage()
        {
            VmBase model = new VmBase()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
