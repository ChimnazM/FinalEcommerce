using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class FaqPageController : Controller
    {
        private readonly AppDbContext _context;

        public FaqPageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Faq> faqs = _context.Faqs.ToList();

            return View(faqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faq model)
        {
            if (ModelState.IsValid)
            {
                _context.Faqs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("index", "faqpage");
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Faq model = _context.Faqs.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Faq model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                //_context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("index", "faqpage");

            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Faq model = _context.Faqs.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.Faqs.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("index", "faqpage");
        }

    }
}
