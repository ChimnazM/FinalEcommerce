using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            List<CustomUser> customUsers = _context.CustomUsers.Include(c=>c.Country).ToList();

            List<IdentityUserRole<string>> userRoles = _context.UserRoles.ToList();
            List<IdentityRole> roles = _context.Roles.ToList();
            


            VmUsers model = new VmUsers()
            {
                CustomUsers =customUsers,
                UserRoles = userRoles,
                Roles = roles
            };

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUser(string id)
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id = 0, Name = "Select*" });
            ViewBag.Country = countries;

            CustomUser user = _context.CustomUsers.Find(id);
            var userRole = _context.UserRoles.FirstOrDefault(r => r.UserId == id);

            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var item in _context.Roles.ToList())
            {
                roles.Add(new SelectListItem()
                {
                    Value = item.Id,
                    Text = item.Name
                });
            }

            user.Roles = roles;
            if (userRole != null)
            {
                user.RoleId = userRole.RoleId;
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(CustomUser model)
        {
            if (model.CountryId == 0)
            {
                ModelState.AddModelError("CountryId", "Please select your country");
                return View(model);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    CustomUser user = _context.CustomUsers.Find(model.Id);
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.ZipCode = model.ZipCode;
                    user.State = model.State;
                    user.CountryId = model.CountryId;

                    //Append Role
                    var selectedRole = _context.Roles.Find(model.RoleId);

                    if (selectedRole == null)
                    {
                        return NotFound();
                    }

                    //Find old role
                    var oldRole = _context.UserRoles.FirstOrDefault(r => r.UserId == user.Id);


                    //Remove old role
                    if (oldRole != null)
                    {
                        //Old role name
                        var oldRoleName = _context.Roles.Find(oldRole.RoleId).Name;

                        //Remove
                        await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                    }

                    //Add new role
                    await _userManager.AddToRoleAsync(user, selectedRole.Name);

                    //update
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("users", "account");
                }

            }


            return View(model);
        }


        ///Role
        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            List<IdentityRole> roles = _context.Roles.ToList();
            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model)
        {
            var result = await _roleManager.CreateAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("roles", "account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }

        [Authorize(Roles = "Admin, Moderator, Accountant")]
        public IActionResult Countries()
        {
            List<Country> countries = _context.Countries.ToList();

            return View(countries);
        }

        [Authorize(Roles = "Admin, Moderator, Accountant")]
        public IActionResult CreateCountry()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator, Accountant")]
        [HttpPost]
        public IActionResult CreateCountry(Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(model);
                _context.SaveChanges();
                return RedirectToAction("countries", "account");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Accountant")]
        public IActionResult UpdateCountry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country model = _context.Countries.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [Authorize(Roles = "Admin, Moderator, Accountant")]
        [HttpPost]
        public IActionResult UpdateCountry(Country model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("countries", "account");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator, Accountant")]
        public IActionResult DeleteCountry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country model = _context.Countries.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Countries.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("countries", "account");
        }


    }
}
