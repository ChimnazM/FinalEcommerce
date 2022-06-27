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
using Shopwise.ViewModels;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class ShopPageController : Controller
    {
        private readonly AppDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ShopPageController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Sale()
        {
            List<Sale> sales = _context.Sales.Include(c => c.Country).ToList();
            decimal subtotal = 0;
            List<VmSale> vmSales = new List<VmSale>();

            foreach (var item in sales)
            {
                List<SaleItem> saleItems = _context.SaleItems.Where(s => s.SaleId == item.Id).ToList();

                //User Client
                CustomUser customUser = _context.CustomUsers.Include(c=>c.Country).FirstOrDefault(u=>u.Id == item.CustomUserId);

                foreach (var saleItem in saleItems)
                {
                    subtotal += saleItem.Price;
                }

                VmSale vmSale = new VmSale()
                {
                    Id = item.Id,
                    InvoiceNo = item.InvoiceNo,
                    TotalPrice = item.TotalPrice,
                    Tax = item.TotalPrice - subtotal - item.ShippingPrice,
                    ShippingCountry = item.Country.Name,
                    CustomUserFullName = customUser.Name + " " + customUser.Surname,
                    Date = item.Date,
                    ShippingPrice = item.ShippingPrice
                };

                vmSales.Add(vmSale);

                subtotal = 0;
            }

            return View(vmSales);
        }

        public IActionResult SaleItem(int? saleId)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            if (saleId != null)
            {
                saleItems = _context.SaleItems.Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).ThenInclude(pi => pi.ProductImages).Include(b => b.AllInfoToProduct).ThenInclude(c => c.Color).Include(s => s.AllInfoToProduct).ThenInclude(si => si.Size).Where(item=>item.SaleId == saleId).ToList();
            }
            else
            {
                saleItems = _context.SaleItems.Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).ThenInclude(pi => pi.ProductImages).Include(b => b.AllInfoToProduct).ThenInclude(c => c.Color).Include(s => s.AllInfoToProduct).ThenInclude(si => si.Size).ToList();
            }

            return View(saleItems);
        }

        public IActionResult Tax()
        {
            Tax tax = _context.Tax.FirstOrDefault();
            return View(tax);
        }

        public IActionResult CreateTax()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTax(Tax model)
        {
            if (ModelState.IsValid)
            {
                _context.Tax.Add(model);
                _context.SaveChanges();

                return RedirectToAction("tax", "shoppage");

            }

            return View(model);
        }

        public IActionResult UpdateTax(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Tax model = _context.Tax.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTax(Tax model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("tax", "shoppage");

            }

            return View(model);
        }

        public IActionResult DeleteTax(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Tax model = _context.Tax.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete tax
            _context.Tax.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("tax", "shoppage");
        }


        //Advertisement
        #region Advertisement
        public IActionResult Advertisement()
        {
            Advertisement shopAdvertisement = _context.Advertisements.FirstOrDefault(s => s.Section == "Shop");
            return View(shopAdvertisement);
        }

        public IActionResult CreateAdvertisement()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateAdvertisement(Advertisement model)
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
                            model.Section = "Shop";
                            model.Image = fileName;
                            _context.Advertisements.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("advertisement", "shoppage");
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

        public IActionResult UpdateAdvertisement(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Advertisement model = _context.Advertisements.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateAdvertisement(Advertisement model)
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
                            _context.Entry(model).Property(a => a.Section).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("advertisement", "shoppage");
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

                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();
                return RedirectToAction("advertisement", "shoppage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteAdvertisement(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Advertisement model = _context.Advertisements.Find(id);

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

            //delete slider
            _context.Advertisements.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Advertisement", "shoppage");
        }

        #endregion
    }
}
