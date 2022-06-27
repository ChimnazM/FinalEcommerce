using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace Shopwise.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppDbContext _context;

        [Obsolete]
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHostingEnvironment hostingEnvironment, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        [Authorize]
        public IActionResult Profile()
        {
            //Find User
            string userId = _userManager.GetUserId(User);
            CustomUser user = _context.CustomUsers.Find(userId);

            VmProfile model = new VmProfile()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                State = user.State,
                Zipcode = user.ZipCode,
                Image = user.Image,
                Country = _context.Countries.Find(user.CountryId).Name
            };

            return View(model);
        }

        [Authorize]
        public IActionResult UpdateProfile()
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id = 0, Name = "Select*" });
            ViewBag.Country = countries;

            //Find User
            string userId = _userManager.GetUserId(User);
            CustomUser user = _context.CustomUsers.Find(userId);

            VmProfile model = new VmProfile()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                State = user.State,
                Zipcode = user.ZipCode,
                Image = user.Image,
                CountryId = user.CountryId
            };

            return View(model);
        }



        [HttpPost]
        [Authorize]
        [Obsolete]
        public IActionResult UpdateProfile(VmProfile model)
        {
            //Find User
            string userId = _userManager.GetUserId(User);
            CustomUser user = _context.CustomUsers.Find(userId);

            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            if (model.Image != null)
                            {
                                //delete old picture if old picture is exist
                                string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/User", model.Image);
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }
                           

                            //add new picture
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/User", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            user.Name = model.Name;
                            user.Surname = model.Surname;
                            user.Email = model.Email;
                            user.Phone = model.Phone;
                            user.ZipCode = model.Zipcode;
                            user.State = model.State;
                            user.CountryId = model.CountryId;
                            user.Image = model.Image;

                            //update
                            _context.Entry(user).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            //_context.Entry(model).Property(a => a.Title).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("profile", "account");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                        return View(model);
                    }
                }

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.ZipCode = model.Zipcode;
                user.State = model.State;
                user.CountryId = model.CountryId;
                //update
                _context.Entry(user).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                //_context.Entry(model).Property(a => a.Title).IsModified = false;

                _context.SaveChanges();
                return RedirectToAction("profile", "account");

            };


            return View(model);
        }

        [Authorize]
        public IActionResult MyOrders()
        {
            //Find User
            string userId = _userManager.GetUserId(User);
            CustomUser user = _context.CustomUsers.Find(userId);

            List<VmOrder> vmOrders = new List<VmOrder>();
            List<Sale> sales = _context.Sales.Where(s => s.CustomUserId == userId).ToList();
            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var sale in sales)
            {
                List<SaleItem> currentSaleItems = _context.SaleItems.Include(s=>s.Sale).Include(p=>p.AllInfoToProduct).ThenInclude(a=>a.Product).ThenInclude(i=>i.ProductImages).Where(s => s.SaleId == sale.Id).Include(p => p.AllInfoToProduct).ThenInclude(color=>color.Color).Include(p => p.AllInfoToProduct).ThenInclude(size => size.Size).ToList();

                foreach (var saleitem in currentSaleItems)
                {
                    saleItems.Add(saleitem);
                }
            }




            VmOrder model = new VmOrder()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                SaleItems = saleItems,
                Sales = sales
            };

            return View(model);
        }

        public IActionResult Invoice(int? saleId)
        {
            if (saleId == null)
            {
                return RedirectToAction("Errorpage","home");
            }

            Sale sale = _context.Sales.Include(c=>c.CustomUser).Include(ct=>ct.Country).FirstOrDefault(s=>s.Id == saleId);

            if (sale == null)
            {
                return RedirectToAction("Errorpage", "home");
            }

            List<SaleItem> saleItems = _context.SaleItems.Include(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product)
                                                        .Include(a => a.AllInfoToProduct).ThenInclude(c=>c.Color)
                                                        .Include(a => a.AllInfoToProduct).ThenInclude(s => s.Size)
                                                        .Where(s => s.SaleId == saleId).ToList();

            decimal subtotal = 0;

            foreach (var item in saleItems)
            {
                subtotal += item.Quantity * item.Price;
            }


            VmInvoice model = new VmInvoice()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                Sale = sale,
                SaleItems = saleItems,
                Subtotal = subtotal,
                isPdf = false
            };

            return View(model);
        }

        public IActionResult PdfInvoice(int? saleId)
        {
            if (saleId == null)
            {
                return RedirectToAction("Errorpage", "home");
            }

            Sale sale = _context.Sales.Include(c => c.CustomUser).Include(ct => ct.Country).FirstOrDefault(s => s.Id == saleId);

            if (sale == null)
            {
                return RedirectToAction("Errorpage", "home");
            }

            List<SaleItem> saleItems = _context.SaleItems.Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product)
                                                        .Include(a => a.AllInfoToProduct).ThenInclude(c => c.Color)
                                                        .Include(a => a.AllInfoToProduct).ThenInclude(s => s.Size)
                                                        .Where(s => s.SaleId == saleId).ToList();

            decimal subtotal = 0;

            foreach (var item in saleItems)
            {
                subtotal += item.Quantity * item.Price;
            }


            VmInvoice model = new VmInvoice()
            {
                Sale = sale,
                SaleItems = saleItems,
                Subtotal = subtotal,
                isPdf = true
            };

            int pageHeight = 160 + saleItems.Count * 6;

            return new ViewAsPdf("Invoice", model)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(0, 0, 0, 0),
                PageWidth = 210,
                PageHeight = pageHeight
            };
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            VmChangePassword model = new VmChangePassword()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(VmChangePassword model)
        {
            
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login","account");
                }

                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    Notify("The password has not been changed!", notificationType: NotificationType.error);
                    ModelState.AddModelError("", "New Password or Confirm Password is incorrect.");
                }
                else
                {
                    var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                    if (!result.Succeeded)
                    {
                        Notify("The password has not been changed!", notificationType: NotificationType.error);
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    await _signInManager.RefreshSignInAsync(user);
                    if (result.Succeeded)
                    {
                        Notify("Password Changed successfully");
                        return RedirectToAction("profile", "account");
                    }
                }
                
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



        [AllowAnonymous]
        public IActionResult Login(string email, bool? isCart)
        {
            if (isCart != null)
            {
                ViewBag.IsCart = isCart;
            }
            VmLogin model = new VmLogin()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                Email = email,
                isCart = isCart
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(VmLogin model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    Notify("Login successfully");

                    if (model.isCart == true)
                    {
                        return RedirectToAction("checkout", "shop");
                    }

                    return RedirectToAction("index", "home");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                    
                }
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

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            VmRegister model = new VmRegister()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (ModelState.IsValid)
            {
                var customUser = new CustomUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(customUser, model.Password);

                //Role elage elemek
                await _userManager.AddToRoleAsync(customUser, "Customer");


                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(customUser, false);
                    return RedirectToAction("index","home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
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

        //Forgot Password
        public IActionResult ForgotPassword()
        {
            VmForgotPassword model = new VmForgotPassword()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
            };

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(VmForgotPassword model)
        {
            //layout
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Universals = _context.Universal.ToList();
            model.Payments = _context.Payments.ToList();
            model.Contacts = _context.Contacts.ToList();
            model.ContactInfo = _context.ContactInfo.FirstOrDefault();

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null /*&& await _userManager.IsEmailConfirmedAsync(user)*/)
                {
                    // Generate the reset password token
                    var token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));


                    //Sending mail
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("shopwise.web.com@gmail.com", "Shopwise");
                    mail.To.Add(model.Email);
                    mail.Body = "<h1>Hello!</h1> <br />" +
                        "<p>For resetting password please visit the link below</p>" +
                        "<a href='https://localhost:44392/account/resetpassword?email=" + model.Email + "&token=" + token + "'>Reset password</a>";

                    mail.IsBodyHtml = true;
                    mail.Subject = "Reset password";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("shopwise.web.com@gmail.com", "Agil123@");

                    smtpClient.Send(mail);
                    //End of sending mail


                    Notify("Please check your email account for reseting password.");
                }

                return RedirectToAction("login", "account");
            }

            return View(model);
        }


        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {

            if (token == null || email == null)
            {
                Notify("Invalid password reset token!", notificationType: NotificationType.error);
                ModelState.AddModelError("", "Invalid password reset token");
            }

            VmResetPassword model = new VmResetPassword()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(VmResetPassword model)
        {
            //layout
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Universals = _context.Universal.ToList();
            model.Payments = _context.Payments.ToList();
            model.Contacts = _context.Contacts.ToList();
            model.ContactInfo = _context.ContactInfo.FirstOrDefault();

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {

                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        Notify("Password changed successfully");
                        return RedirectToAction("login", "account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }


                return RedirectToAction("login", "account");
            }

            return View(model);
        }


        //Access Denied page
        public IActionResult AccessDenied()
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

        
    }
}
