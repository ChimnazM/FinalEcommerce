using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class ContactPageController : Controller
    {
        private readonly AppDbContext _context;

        public ContactPageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ContactInfo contactInfo = _context.ContactInfo.FirstOrDefault();
            return View(contactInfo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactInfo.Add(model);
                _context.SaveChanges();
                return RedirectToAction("index", "contactpage");
            }

            return View(model);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactInfo model = _context.ContactInfo.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ContactInfo model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                //_context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("index", "contactpage");

            }

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactInfo model = _context.ContactInfo.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.ContactInfo.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("index", "contactpage");
        }

        public IActionResult Message()
        {
            List<ContactMessage> contactMessages = _context.ContactMessages.ToList();
            return View(contactMessages);
        }

        public IActionResult DeleteMessage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactMessage model = _context.ContactMessages.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete message
            _context.ContactMessages.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Message", "contactpage");
        }

        public IActionResult Subscribe()
        {
            List<Subscribe> subscribes = _context.Subscribes.ToList();
            return View(subscribes);
        }

        public IActionResult DeleteSubscribe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscribe model = _context.Subscribes.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete message
            _context.Subscribes.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Subscribe", "contactpage");
        }



    }
}
