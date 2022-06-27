using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmFaq model = new VmFaq()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                Faqs = _context.Faqs.ToList(),
            };

            return View(model);
        }
    }
}
