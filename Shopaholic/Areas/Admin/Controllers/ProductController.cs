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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ProductController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        #region Products

        public IActionResult Index()
        {
            VmProduct model = new VmProduct()
            {
                Products = _context.Products.Include(i => i.ProductImages).Include(c => c.Category).Include(g => g.Gender).ToList(),
                ProductImages = _context.ProductImages.ToList()
            };

            return View(model);
        }

        public IActionResult CreateProduct()
        {
            List<Category> categories = _context.Categories.ToList();
            categories.Insert(0, new Category() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            List<Gender> genders = _context.Gender.ToList();
            genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
            ViewBag.Genders = genders;

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryId == 0 && model.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", "You must select any category for product.");
                    ModelState.AddModelError("GenderId", "You must select any gender for product.");


                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);
                }
                if (model.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", "You must select any category for product.");

                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);
                }
                if (model.GenderId == 0)
                {
                    ModelState.AddModelError("GenderId", "You must select any gender for product.");

                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);

                }

                model.AddedDate = DateTime.Now;
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction("index", "product");
            }
            return View(model);
        }

        public IActionResult UpdateProduct(int? id)
        {
            List<Category> categories = _context.Categories.ToList();
            categories.Insert(0, new Category() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            List<Gender> genders = _context.Gender.ToList();
            genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
            ViewBag.Genders = genders;

            if (id == null)
            {
                return NotFound();
            }

            Product model = _context.Products.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryId == 0 && model.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", "You must select any category for product.");
                    ModelState.AddModelError("GenderId", "You must select any gender for product.");


                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);
                }
                if (model.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", "You must select any category for product.");

                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);
                }
                if (model.GenderId == 0)
                {
                    ModelState.AddModelError("GenderId", "You must select any gender for product.");

                    List<Category> categories = _context.Categories.ToList();
                    categories.Insert(0, new Category() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<Gender> genders = _context.Gender.ToList();
                    genders.Insert(0, new Gender() { Id = 0, Name = "Select" });
                    ViewBag.Genders = genders;

                    return View(model);

                }

                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.AddedDate).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("index", "product");
            }

            return View(model);
        }

        public IActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product model = _context.Products.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete 
            _context.Products.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("index", "product");
        }

        #endregion


        public IActionResult Infos(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product product = _context.Products.Include(d => d.ProductDescriptions).Include(f => f.ProductFeatures).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            VmProduct model = new VmProduct()
            {
                Product = product,
                ProductDescription = _context.ProductDescriptions.FirstOrDefault(d => d.ProductId == id),
                ProductFeatures = _context.ProductFeatures.Where(f => f.ProductId == id).ToList()
            };

            return View(model);
        }

        #region Description

        public IActionResult CreateDescription(int? prodId)
        {
            if (prodId == null)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(prodId);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.ProductId = prodId;

            return View();
        }

        [HttpPost]
        public IActionResult CreateDescription(ProductDescription model)
        {

            if (ModelState.IsValid)
            {

                _context.ProductDescriptions.Add(model);
                _context.SaveChanges();
                int productId = model.ProductId;

                return RedirectToAction("infos", new { id = productId });
            };



            return View(model);
        }

        public IActionResult UpdateDescription(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductDescription model = _context.ProductDescriptions.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateDescription(ProductDescription model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.ProductId).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("infos", new { id = model.ProductId });
            }

            return View(model);
        }

        public IActionResult DeleteDescription(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductDescription model = _context.ProductDescriptions.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete 
            _context.ProductDescriptions.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("infos", new { id = model.ProductId });

        }

        #endregion

        #region Features

        public IActionResult CreateFeature(int? prodId)
        {
            if (prodId == null)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(prodId);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.ProductId = prodId;

            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(ProductFeature model)
        {

            if (ModelState.IsValid)
            {
                _context.ProductFeatures.Add(model);
                _context.SaveChanges();
                int productId = model.ProductId;

                return RedirectToAction("infos", new { id = productId });
            };



            return View(model);
        }

        public IActionResult UpdateFeature(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductFeature model = _context.ProductFeatures.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateFeature(ProductFeature model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                //if i dont want change something - title is a example property
                _context.Entry(model).Property(a => a.ProductId).IsModified = false;

                _context.SaveChanges();

                return RedirectToAction("infos", new { id = model.ProductId });
            }

            return View(model);
        }

        public IActionResult DeleteFeature(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductFeature model = _context.ProductFeatures.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete 
            _context.ProductFeatures.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("infos", new { id = model.ProductId });

        }

        #endregion

        #region Types

        public IActionResult Types(int productId)
        {
            if (productId == 0)
            {
                return NotFound();
            }

            Product product = _context.Products.Include(i => i.ProductImages).FirstOrDefault(p=>p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            VmProduct model = new VmProduct()
            {
                Product = product,
                AllInfoToProducts = _context.AllInfoToProducts.Include(i => i.Product).ThenInclude(ip => ip.ProductImages).Include(c => c.Color).Include(s => s.Size).Where(p => p.ProductId == product.Id).ToList()
            };

            return View(model);
        }

        public IActionResult CreateType(int? prodId)
        {
            if (prodId == null)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(prodId);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.ProductId = prodId;

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            List<Size> sizes = _context.Sizes.ToList();
            sizes.Insert(0, new Size() { Id = 0, Name = "Select" });
            ViewBag.Sizes = sizes;

            return View();
        }

        [HttpPost]
        public IActionResult CreateType(AllInfoToProduct model)
        {
            if (ModelState.IsValid)
            {
                if (model.ColorId == 0 && model.SizeId == 0)
                {
                    ModelState.AddModelError("ColorId", "You must select any color for product.");
                    ModelState.AddModelError("SizeId", "You must select any size for product.");

                }
                else
                {

                    if (model.ColorId != 0)
                    {
                        if (model.SizeId != 0)
                        {
                            _context.AllInfoToProducts.Add(model);
                            _context.SaveChanges();

                            return RedirectToAction("types", new { productId = model.ProductId });
                        }
                        else
                        {
                            ModelState.AddModelError("SizeId", "You must select any size for product.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ColorId", "You must select any color for product.");
                    }
                }
            }

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            List<Size> sizes = _context.Sizes.ToList();
            sizes.Insert(0, new Size() { Id = 0, Name = "Select" });
            ViewBag.Sizes = sizes;

            ViewBag.ProductId = model.ProductId;


            return View(model);
        }

        public IActionResult UpdateType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AllInfoToProduct model = _context.AllInfoToProducts.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            List<Size> sizes = _context.Sizes.ToList();
            sizes.Insert(0, new Size() { Id = 0, Name = "Select" });
            ViewBag.Sizes = sizes;


            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateType(AllInfoToProduct model)
        {
            if (ModelState.IsValid)
            {
                if (model.ColorId == 0 && model.SizeId == 0)
                {
                    ModelState.AddModelError("ColorId", "You must select any color for product.");
                    ModelState.AddModelError("SizeId", "You must select any size for product.");

                }
                else
                {

                    if (model.ColorId != 0)
                    {
                        if (model.SizeId != 0)
                        {
                            //update
                            _context.Entry(model).State = EntityState.Modified;

                            //if i dont want change something - title is a example property
                            _context.Entry(model).Property(a => a.ProductId).IsModified = false;

                            _context.SaveChanges();

                            return RedirectToAction("types", new { productId = model.ProductId });
                        }
                        else
                        {
                            ModelState.AddModelError("SizeId", "You must select any size for product.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ColorId", "You must select any color for product.");
                    }
                }
            }

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            List<Size> sizes = _context.Sizes.ToList();
            sizes.Insert(0, new Size() { Id = 0, Name = "Select" });
            ViewBag.Sizes = sizes;

            return View(model);
        }

        public IActionResult DeleteType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AllInfoToProduct model = _context.AllInfoToProducts.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete 
            _context.AllInfoToProducts.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Types", new { productId = model.ProductId });

        }


        #endregion

        #region Images
        public IActionResult Images(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            VmProduct model = new VmProduct()
            {
                Product = product,
                ProductImages = _context.ProductImages.Include(c => c.Color).Where(p => p.ProductId == product.Id).ToList()
            };

            return View(model);
        }

        public IActionResult CreateImage(int? prodId)
        {
            if (prodId == null)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(prodId);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.ProductId = prodId;

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CreateImage(ProductImage model)
        {
            if (ModelState.IsValid)
            {
                if (model.ColorId != 0)
                {
                    if (model.ImageFile != null)
                    {
                        if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                        {
                            if (model.ImageFile.Length <= 5242880)
                            {
                                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;

                                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/Product", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    model.ImageFile.CopyTo(stream);
                                }

                                model.Image = fileName;
                                _context.ProductImages.Add(model);
                                _context.SaveChanges();
                                return RedirectToAction("Images", new { id = model.ProductId });
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

                }
                else
                {
                    ModelState.AddModelError("ColorId", "You must select any color for product image.");
                }


                List<Color> colors = _context.Colors.ToList();
                colors.Insert(0, new Color() { Id = 0, Name = "Select" });
                ViewBag.Colors = colors;

                ViewBag.ProductId = model.ProductId;


            };

            return View(model);
        }

        public IActionResult UpdateImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductImage model = _context.ProductImages.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            List<Color> colors = _context.Colors.ToList();
            colors.Insert(0, new Color() { Id = 0, Name = "Select" });
            ViewBag.Colors = colors;

            return View(model);

        }

        [HttpPost]
      [Obsolete]
        public IActionResult UpdateImage(ProductImage model)
        {
            if (ModelState.IsValid)
            {
                if (model.ColorId != 0)
                {
                    if (model.ImageFile != null)
                    {
                        if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                        {
                            if (model.ImageFile.Length <= 5242880)
                            {
                                //delete old picture
                                string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/Product", model.Image);
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }

                                //add new picture
                                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/Product", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    model.ImageFile.CopyTo(stream);
                                }

                                model.Image = fileName;

                                //update
                                _context.Entry(model).State = EntityState.Modified;

                                //if i dont want change something
                                _context.Entry(model).Property(a => a.ProductId).IsModified = false;

                                _context.SaveChanges();
                                return RedirectToAction("Images", new { id = model.ProductId });

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

                        //if i dont want change something
                        _context.Entry(model).Property(a => a.ProductId).IsModified = false;

                        _context.SaveChanges();
                        return RedirectToAction("Images", new { id = model.ProductId });
                    }

                }
                else
                {
                    ModelState.AddModelError("ColorId", "You must select any color for product image.");
                }

                List<Color> colors = _context.Colors.ToList();
                colors.Insert(0, new Color() { Id = 0, Name = "Select" });
                ViewBag.Colors = colors;

            };

            return View(model);
        }

        [Obsolete]
        public IActionResult DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductImage model = _context.ProductImages.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete old picture
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/Product", model.Image);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            //delete
            _context.ProductImages.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Images", new { id = model.ProductId });

        }
        #endregion

        public IActionResult Comments(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Comment> comments = _context.Comments.Where(c=>c.ProductId == id).ToList();
            List<VmComment> commentList = new List<VmComment>();

            foreach (var item in comments)
            {
                CustomUser customUser = _context.CustomUsers.Find(item.CustomUserId);
                VmComment vmComment = new VmComment()
                {
                    Id = item.Id,
                    Text = item.Text,
                    Rating = item.Rating,
                    CustomUserFullname = customUser.Name +" "+ customUser.Surname,
                    AddedDate = item.AddedDate
                };
                commentList.Add(vmComment);
            }

            return View(commentList);
        }

        public IActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment model = _context.Comments.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Comments.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Comments", "Product", new { id = model.ProductId });
        }


        public IActionResult Categories()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Categories", "Product");
            }

            return View(model);
        }

        public IActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category model = _context.Categories.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Categories", "Product");
            }

            return View(model);
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category model = _context.Categories.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Categories.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Categories", "Product");
        }






        public IActionResult Genders()
        {
            List<Gender> genders = _context.Gender.ToList();
            return View(genders);
        }

        public IActionResult CreateGender()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGender(Gender model)
        {
            if (ModelState.IsValid)
            {
                _context.Gender.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Genders", "Product");
            }

            return View(model);
        }

        public IActionResult UpdateGender(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender model = _context.Gender.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateGender(Gender model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Genders", "Product");
            }

            return View(model);
        }

        public IActionResult DeleteGender(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender model = _context.Gender.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Gender.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Genders", "Product");
        }




        public IActionResult Colors()
        {
            List<Color> colors = _context.Colors.ToList();
            return View(colors);
        }

        public IActionResult CreateColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateColor(Color model)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Colors", "Product");
            }

            return View(model);
        }

        public IActionResult UpdateColor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color model = _context.Colors.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateColor(Color model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Colors", "Product");
            }

            return View(model);
        }

        public IActionResult DeleteColor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color model = _context.Colors.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Colors.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Colors", "Product");
        }




        public IActionResult Sizes()
        {
            List<Size> sizes = _context.Sizes.ToList();
            return View(sizes);
        }

        public IActionResult CreateSize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSize(Size model)
        {
            if (ModelState.IsValid)
            {
                _context.Sizes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Sizes", "Product");
            }

            return View(model);
        }

        public IActionResult UpdateSize(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Size model = _context.Sizes.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateSize(Size model)
        {
            if (ModelState.IsValid)
            {
                //update
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Sizes", "Product");
            }

            return View(model);
        }

        public IActionResult DeleteSize(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Size model = _context.Sizes.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            //delete 
            _context.Sizes.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Sizes", "Product");
        }

    }
}
