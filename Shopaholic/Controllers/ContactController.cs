using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Controllers
{
    public class ContactController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public ContactController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            VmContact model = new VmContact()
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

        [HttpPost]
        public IActionResult Index(VmContact model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                //Find User
                string userId = _userManager.GetUserId(User);
                CustomUser user = _context.CustomUsers.Find(userId);

                model.Name = user.Name;
                model.Surname = user.Surname;
                model.Email = user.Email;
                model.Phone = user.Phone;
            }

            if (ModelState.IsValid)
            {
                ContactMessage message = new ContactMessage()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Message = model.Message
                };

                _context.ContactMessages.Add(message);
                _context.SaveChanges();

                Notify("Your message sent successfully");

                return RedirectToAction("index", "home");
            }

            //layout
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Universals = _context.Universal.ToList();
            model.Payments = _context.Payments.ToList();
            model.Contacts = _context.Contacts.ToList();
            model.ContactInfo = _context.ContactInfo.FirstOrDefault();

            return View(model);
        }


        public JsonResult addSubscribe(string email)
        {
            if (email == null)
            {
                return Json(404);
            }

            bool isExist = _context.Subscribes.Any(e=>e.Email == email);

            if (isExist)
            {
                return Json(505);
            }

            Subscribe subscribe = new Subscribe()
            {
                Email = email,
                AddedDate = DateTime.Now
            };

            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();

            return Json(200);
        }
    }
}
