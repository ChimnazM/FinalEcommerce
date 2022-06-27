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
    public class AboutPageController : Controller
    {
        private readonly AppDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public AboutPageController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //About Us
        #region AboutUs
        public IActionResult AboutUs()
        {
            About aboutUs = _context.About.FirstOrDefault();
            return View(aboutUs);
        }

        public IActionResult CreateAboutUs()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateAboutUs(About model)
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
                            _context.About.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("aboutus", "aboutpage");
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

        public IActionResult UpdateAboutUs(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            About model = _context.About.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateAboutUs(About model)
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
                            return RedirectToAction("aboutus", "aboutpage");
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
                return RedirectToAction("aboutus", "aboutpage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteAboutUs(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            About model = _context.About.Find(id);

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
            _context.About.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("aboutus", "aboutpage");
        }
        #endregion


        //Choose Us
        public IActionResult ChooseUs()
        {
            VmChooseUs model = new VmChooseUs()
            {
                Universal = _context.Universal.Where(s => s.Section == "ChooseUs").FirstOrDefault(),
                ChooseUs = _context.ChooseUs.ToList()
            };

            return View(model);
        }

        #region ChooseUsHeader
        public IActionResult CreateChooseUsHeader()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChooseUsHeader(Universal model)
        {
            if (ModelState.IsValid)
            {
                model.Section = "ChooseUs";
                _context.Universal.Add(model);
                _context.SaveChanges();

                return RedirectToAction("chooseus", "aboutpage");

            }
            return View(model);
        }

        public IActionResult UpdateChooseUsHeader(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Universal model = _context.Universal.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateChooseUsHeader(Universal model)
        {
            if (ModelState.IsValid)
            {
                

                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("chooseUs", "Aboutpage");

            }

            return View(model);
        }

        public IActionResult DeleteChooseUsHeader(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Universal model = _context.Universal.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.Universal.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("chooseUs", "aboutpage");
        }
        #endregion

        #region ChooseUsCards
        public IActionResult CreateChooseUsCard()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateChooseUsCard(ChooseUs model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif" || model.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;

                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Icon = fileName;
                            _context.ChooseUs.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("chooseus", "aboutpage");
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

        public IActionResult UpdateChooseUsCard(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ChooseUs model = _context.ChooseUs.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateChooseUsCard(ChooseUs model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif" || model.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            //delete old picture
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", model.Icon);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            //add new picture
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Icon = fileName;

                            //update
                            _context.Entry(model).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            //_context.Entry(model).Property(a => a.Title).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("chooseus", "aboutpage");
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
                return RedirectToAction("chooseus", "aboutpage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteChooseUsCard(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ChooseUs model = _context.ChooseUs.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete old picture
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", model.Icon);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            //delete slider
            _context.ChooseUs.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("chooseus", "aboutpage");
        }

        #endregion



        //Our Mission
        public IActionResult OurMission()
        {
            VmMission model = new VmMission()
            {
                Universal = _context.Universal.Where(s => s.Section == "Mission").FirstOrDefault(),
                MissionFeatures = _context.MissionFeatures.ToList(),
                MissionFile = _context.MissionFiles.FirstOrDefault()
            };

            return View(model);
        }

        #region OurMissionHeader
        public IActionResult CreateOurMissionHeader()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOurMissionHeader(Universal model)
        {
            if (ModelState.IsValid)
            {
                model.Section = "Mission";
                _context.Universal.Add(model);
                _context.SaveChanges();

                return RedirectToAction("OurMission", "aboutpage");

            }
            return View(model);
        }

        public IActionResult UpdateOurMissionHeader(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Universal model = _context.Universal.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateOurMissionHeader(Universal model)
        {
            if (ModelState.IsValid)
            {


                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.Section).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("OurMission", "Aboutpage");

            }

            return View(model);
        }

        public IActionResult DeleteOurMissionHeader(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Universal model = _context.Universal.Find(id);

            if (model == null)
            {
                return NotFound();
            }


            //delete testimonial
            _context.Universal.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("OurMission", "aboutpage");
        }
        #endregion

        #region OurMissionFeature
        public IActionResult CreateOurMissionCard()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateOurMissionCard(MissionFeature model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif" || model.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;

                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Icon = fileName;
                            _context.MissionFeatures.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("OurMission", "aboutpage");
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

        public IActionResult UpdateOurMissionCard(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            MissionFeature model = _context.MissionFeatures.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateOurMissionCard(MissionFeature model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif" || model.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            //delete old picture
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", model.Icon);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            //add new picture
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Icon = fileName;

                            //update
                            _context.Entry(model).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            //_context.Entry(model).Property(a => a.Title).IsModified = false;

                            _context.SaveChanges();
                            return RedirectToAction("OurMission", "aboutpage");
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
                return RedirectToAction("OurMission", "aboutpage");

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteOurMissionCard(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            MissionFeature model = _context.MissionFeatures.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete old picture
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Icons", model.Icon);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            //delete slider
            _context.MissionFeatures.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("OurMission", "aboutpage");
        }
        #endregion

        #region OurMissionFile
        public IActionResult CreateOurMissionFile()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateOurMissionFile(MissionFile model)
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
                            _context.MissionFiles.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("OurMission", "aboutpage");
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

        public IActionResult UpdateOurMissionFile(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            MissionFile model = _context.MissionFiles.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult UpdateOurMissionFile(MissionFile model)
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
                            return RedirectToAction("OurMission", "aboutpage");
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
                return RedirectToAction("OurMission", "aboutpage");

            };

            return View(model);
        }


        [Obsolete]
        public IActionResult OurMissionFile(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            MissionFile model = _context.MissionFiles.Find(id);

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
            _context.MissionFiles.Remove(model);
            _context.SaveChanges();


            return RedirectToAction("OurMission", "aboutpage");
        }

        #endregion

    }
}
