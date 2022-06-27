using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class LayoutController : Controller
    {
        private readonly AppDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public LayoutController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Setting()
        {
            Setting model = _context.Settings.FirstOrDefault();
            return View(model);
        }

        public IActionResult CreateSetting()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateSetting(Setting model)
        {
            bool isFirstOK = false;
            bool isSecondOK = false;

            if (ModelState.IsValid)
            {
                if (model.HeaderImageFile != null && model.FooterImageFile != null)
                {
                    //Check Header Logo
                    if (model.HeaderImageFile.ContentType == "image/jpeg" || model.HeaderImageFile.ContentType == "image/png" || model.HeaderImageFile.ContentType == "image/webp" || model.HeaderImageFile.ContentType == "image/gif")
                    {
                        if (model.HeaderImageFile.Length <= 5242880)
                        {

                            isFirstOK = true;
                        }
                        else
                        {
                            ModelState.AddModelError("HeaderImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("HeaderImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }

                    //Check Footer Logo
                    if (model.FooterImageFile.ContentType == "image/jpeg" || model.FooterImageFile.ContentType == "image/png" || model.FooterImageFile.ContentType == "image/webp" || model.FooterImageFile.ContentType == "image/gif")
                    {
                        if (model.FooterImageFile.Length <= 5242880)
                        {

                            isSecondOK = true;
                        }
                        else
                        {
                            ModelState.AddModelError("FooterImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("FooterImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }


                    if (isFirstOK && isSecondOK)
                    {
                        //File stream of Header Logo
                        string headerFileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.HeaderImageFile.FileName;

                        string headerFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", headerFileName);

                        using (var stream = new FileStream(headerFilePath, FileMode.Create))
                        {
                            model.HeaderImageFile.CopyTo(stream);
                        }

                        //File stream of Footer Logo
                        string footerFileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.FooterImageFile.FileName;

                        string fileFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", footerFileName);

                        using (var stream = new FileStream(fileFilePath, FileMode.Create))
                        {
                            model.FooterImageFile.CopyTo(stream);
                        }

                        model.HeaderLogo = headerFileName;
                        model.FooterLogo = footerFileName;
                        _context.Settings.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("setting", "layout");
                    }
                }
                else
                {
                    ModelState.AddModelError("HeaderImageFile", "You must upload image file.");
                    ModelState.AddModelError("FooterImageFile", "You must upload image file.");
                }
            };

            return View(model);
        }

        public IActionResult UpdateSetting(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Setting setting = _context.Settings.Find(id);

            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateSetting(Setting model)
        {
            bool isOk = false;
            bool isFirstOk = false;

            if (ModelState.IsValid)
            {
                if (model.HeaderImageFile != null)
                {
                    if (model.HeaderImageFile.ContentType == "image/jpeg" || model.HeaderImageFile.ContentType == "image/png" || model.HeaderImageFile.ContentType == "image/webp" || model.HeaderImageFile.ContentType == "image/gif")
                    {
                        if (model.HeaderImageFile.Length <= 5242880)
                        {
                            isFirstOk = true;
                            isOk = true;
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }
                }
                else
                {
                    isOk = true;
                }

                if (model.FooterImageFile != null && isOk == true)
                {
                    if (model.FooterImageFile.ContentType == "image/jpeg" || model.FooterImageFile.ContentType == "image/png" || model.FooterImageFile.ContentType == "image/webp" || model.FooterImageFile.ContentType == "image/gif")
                    {
                        if (model.FooterImageFile.Length <= 5242880)
                        {
                            //delete old picture
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.FooterLogo);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            //add new picture
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.FooterImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.FooterImageFile.CopyTo(stream);
                            }

                            model.FooterLogo = fileName;

                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }
                }
                else
                {
                    isOk = true;
                }

                if (isOk)
                {
                    if (isFirstOk)
                    {
                        /* Header Logo */
                        //delete old picture
                        string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.HeaderLogo);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }

                        //add new picture
                        string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.HeaderImageFile.FileName;
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.HeaderImageFile.CopyTo(stream);
                        }

                        model.HeaderLogo = fileName;
                    }

                    //update
                    _context.Entry(model).State = EntityState.Modified;

                    //if i dont want change something - title is a example property
                    //_context.Entry(model).Property(a => a.Title).IsModified = false;

                    _context.SaveChanges();
                    return RedirectToAction("setting", "layout");

                }
            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteSetting(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Setting model = _context.Settings.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete header logo
            string oldFilePathHeader = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.HeaderLogo);
            if (System.IO.File.Exists(oldFilePathHeader))
            {
                System.IO.File.Delete(oldFilePathHeader);
            }

            //delete footer logo
            string oldFilePathFooter = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.FooterLogo);
            if (System.IO.File.Exists(oldFilePathFooter))
            {
                System.IO.File.Delete(oldFilePathFooter);
            }

            //delete slider
            _context.Settings.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("setting", "layout");
        }


        public IActionResult Payment()
        {
            List<Payment> payments = _context.Payments.ToList();
            return View(payments);
        }

        public IActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreatePayment(Payment model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;

                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                            _context.Payments.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("payment", "layout");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "You must upload image file.");
                }

            };

            return View(model);
        }

        public IActionResult UpdatePayment(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Payment model = _context.Payments.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdatePayment(Payment model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            //delete old picture
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.Image);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            //add new picture
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            //update
                            _context.Entry(model).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            //_context.Entry(model).Property(a => a.Title).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("payment", "layout");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                    }
                }
                else
                {
                    //update
                    _context.Entry(model).State = EntityState.Modified;

                    //if i dont want change something - title is a example property
                    //_context.Entry(model).Property(a => a.Title).IsModified = false;

                    _context.SaveChanges();
                    return RedirectToAction("payment", "layout");
                }
            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeletePayment(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Payment model = _context.Payments.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete old picture
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.Image);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            //delete Partner
            _context.Payments.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("payment", "layout");
        }


        public IActionResult Socials()
        {
            List<Social> socials = _context.Socials.ToList();
            return View(socials);
        }

        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocial(Social model)
        {
            if (ModelState.IsValid)
            {
                _context.Socials.Add(model);
                _context.SaveChanges();

                return RedirectToAction("socials", "layout");

            }

            return View(model);
        }

        public IActionResult UpdateSocial(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Social model = _context.Socials.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateSocial(Social model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("socials", "layout");

            }

            return View(model);
        }

        public IActionResult DeleteSocial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Social model = _context.Socials.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete tax
            _context.Socials.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("socials", "layout");
        }


        public IActionResult ContactInfo()
        {
            List<Contact> model = _context.Contacts.ToList();

            return View(model);
        }

        public IActionResult CreateContactInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContactInfo(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(model);
                _context.SaveChanges();

                return RedirectToAction("contactinfo", "layout");

            }

            return View(model);
        }

        public IActionResult UpdateContactInfo(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Contact model = _context.Contacts.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateContactInfo(Contact model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("contactinfo", "layout");

            }

            return View(model);
        }

        public IActionResult DeleteContactInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact model = _context.Contacts.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete tax
            _context.Contacts.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("contactinfo", "layout");
        }
    }
}
