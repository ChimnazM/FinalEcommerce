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
    public class HomePageController : Controller
    {
        private readonly AppDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public HomePageController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //Sliders
        #region Slider

        public IActionResult Slider()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateSlider(Slider model)
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
                            _context.Sliders.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("slider", "homepage");
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

        public IActionResult UpdateSlider(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider slider = _context.Sliders.Find(id);

            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateSlider(Slider model)
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
                            _context.Sliders.Update(model);
                            //_context.Entry(model).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            //_context.Entry(model).Property(a => a.Title).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("slider", "homepage");
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
                //_context.Entry(model).State = EntityState.Modified;
                _context.Sliders.Update(model);

                //if i dont want change something - title is a example property
                //_context.Entry(model).Property(a => a.Title).IsModified = false;

                _context.SaveChanges();
                return RedirectToAction("slider", "homepage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteSlider(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Slider model = _context.Sliders.Find(id);

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
            _context.Sliders.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("slider", "homepage");
        }

        #endregion

        //Advertisement
        #region Advertisement
        public IActionResult Advertisement()
        {
            List<Advertisement> seasons = _context.Advertisements.Where(s => s.Section == "Seasons").ToList();
            return View(seasons);
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
                            model.Section = "Seasons";
                            model.Image = fileName;
                            _context.Advertisements.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("advertisement", "homepage");
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
                            return RedirectToAction("advertisement", "homepage");
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
                return RedirectToAction("advertisement", "homepage");

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


            return RedirectToAction("Advertisement", "homepage");
        }

        #endregion

        //Trend
        #region Trend

        public IActionResult Trend()
        {
            Advertisement trend = _context.Advertisements.Where(s => s.Section == "Trend").FirstOrDefault();
            return View(trend);
        }

        public IActionResult CreateTrend()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateTrend(Advertisement model)
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
                            model.Section = "Trend";
                            model.Image = fileName;
                            _context.Advertisements.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Trend", "homepage");
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

        public IActionResult UpdateTrend(int id)
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
        public IActionResult UpdateTrend(Advertisement model)
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
                            return RedirectToAction("Trend", "homepage");
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
                return RedirectToAction("Trend", "homepage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteTrend(int id)
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


            return RedirectToAction("Trend", "homepage");
        }

        #endregion

        //Testimonial
        #region Testimonial

        public IActionResult Testimonial()
        {
            VmTestimonial model = new VmTestimonial()
            {
                Testimonial = _context.Testimonial.FirstOrDefault(),
                Feedbacks = _context.Feedbacks.ToList()
            };

            return View(model);
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial model)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonial.Add(model);
                _context.SaveChanges();
                return RedirectToAction("testimonial", "homepage");

            }
            return View(model);
        }

        public IActionResult UpdateTestimonial(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Testimonial model = _context.Testimonial.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("testimonial", "homepage");

            }

            return View(model);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Testimonial model = _context.Testimonial.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.Testimonial.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Testimonial", "homepage");
        }

        #endregion

        //FeedBacks
        #region Feedback
        public IActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateFeedback(Feedback model)
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
                            _context.Feedbacks.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("testimonial", "homepage");
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

        public IActionResult UpdateFeedback(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Feedback model = _context.Feedbacks.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateFeedback(Feedback model)
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
                            //_context.Entry(model).Property(a => a.Section).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("testimonial", "homepage");
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
                //_context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();
                return RedirectToAction("testimonial", "homepage");

            };

            return View(model);
        }

        public IActionResult DeleteFeedback(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Feedback model = _context.Feedbacks.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.Feedbacks.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Testimonial", "homepage");
        }
        #endregion

        //Partners
        #region Partners
        public IActionResult Partners()
        {
            List<Partner> partners = _context.Partners.ToList();
            return View(partners);
        }

        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreatePartner(Partner model)
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
                            _context.Partners.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("partners", "homepage");
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

        public IActionResult UpdatePartner(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Partner model = _context.Partners.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdatePartner(Partner model)
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
                            return RedirectToAction("partners", "homepage");
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
                //_context.Entry(model).Property(a => a.Title).IsModified = false;

                _context.SaveChanges();
                return RedirectToAction("partners", "homepage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeletePartner(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Partner model = _context.Partners.Find(id);

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
            _context.Partners.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("Partners", "homepage");
        }
        #endregion


    }
}
