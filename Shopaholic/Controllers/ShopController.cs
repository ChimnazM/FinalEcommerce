using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Controllers
{
    public class ShopController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public ShopController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index(VmShop Productfilter, string searchData, bool? status, int page = 1)
        {
            //Count of item's on page
            decimal pageItemCount = 3;
            ViewBag.Filter = new Dictionary<string, string>
            {
                {"minPrice", Productfilter.minPrice.ToString() },
                {"maxPrice", Productfilter.maxPrice.ToString() },
                {"catId", Productfilter.catId.ToString() },
                {"genId", Productfilter.genId.ToString() },
                {"sizeId", Productfilter.sizeId.ToString() },
                {"colorId", Productfilter.colorId.ToString() },
                {"SortId", Productfilter.SortId.ToString() },

            };

            //Sort Products
            List<VmSort> sorts = new List<VmSort>();
            sorts.Insert(0, new VmSort { Id = 0, Name = "All Products" });
            sorts.Insert(1, new VmSort { Id = 1, Name = "Sort by average rating" });
            sorts.Insert(2, new VmSort { Id = 2, Name = "Sort by latest" });
            sorts.Insert(3, new VmSort { Id = 3, Name = "Sort by price: low to high" });
            sorts.Insert(4, new VmSort { Id = 4, Name = "Sort by price: high to low" });
            ViewBag.Sorts = sorts;

            if (status == null)
            {
                status = true;
            }

            List<Product> productList = _context.Products.Include(t=>t.AllInfoToProducts).Where(p => (Productfilter.catId != null? p.CategoryId == Productfilter.catId : true) && 
                                                                  (Productfilter.genId != null ? p.GenderId == Productfilter.genId : true) && 
                                                                  (Productfilter.colorId != null ? p.AllInfoToProducts.Any(c => c.ColorId == Productfilter.colorId) : true) && 
                                                                  (Productfilter.sizeId != null ? p.AllInfoToProducts.Any(c => c.SizeId == Productfilter.sizeId) : true) &&
                                                                  (Productfilter.minPrice != null ? p.AllInfoToProducts.FirstOrDefault().Price >= Productfilter.minPrice : true) &&
                                                                  (Productfilter.maxPrice != null ? p.AllInfoToProducts.FirstOrDefault().Price <= Productfilter.maxPrice : true) &&
                                                                  (status == true ? p.AllInfoToProducts.Any(q=>q.Quantity > 0) : true) &&
                                                                  (status == false ? p.AllInfoToProducts.All(q=>q.Quantity == 0) : true) &&
                                                                  ((searchData != null ? p.Name.Contains(searchData) : true) || (searchData != null ? p.Category.Name.Contains(searchData):true)))
                                                                  .ToList();

            decimal a = productList.Count() / pageItemCount;
            ViewBag.PageCount = Convert.ToInt32(Math.Ceiling(a));
            ViewBag.ActivePage = page;

            List<Product> products = new List<Product>();


            if (Productfilter.SortId == 1)
            {
                products = productList.OrderBy(o => (o.Comments != null? o.Comments.FirstOrDefault().Rating: o.Id)).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount).ToList();
            }
            else if (Productfilter.SortId == 2)
            {
                products = productList.OrderByDescending(o => o.AddedDate).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount).ToList();
            }
            else if (Productfilter.SortId == 3)
            {
                products = productList.OrderBy(o => (o.AllInfoToProducts.FirstOrDefault().DiscountDeadline > DateTime.Now ? o.AllInfoToProducts.FirstOrDefault().DiscountPrice : o.AllInfoToProducts.FirstOrDefault().Price)).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount).ToList();
            }
            else if (Productfilter.SortId == 4)
            {
                products = productList.OrderByDescending(o => (o.AllInfoToProducts.FirstOrDefault().DiscountDeadline > DateTime.Now ? o.AllInfoToProducts.FirstOrDefault().DiscountPrice : o.AllInfoToProducts.FirstOrDefault().Price)).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount).ToList();
            }
            else
            {
                products = productList.OrderBy(o => o.Id).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount).ToList();
            }

            VmShop model = new VmShop()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                Products = products,
                Genders = _context.Gender.ToList(),
                Colors = _context.Colors.Include(c=>c.AllInfoToProducts).ToList(),
                Sizes = _context.Sizes.Include(s=>s.AllInfoToProducts).ToList(),
                Categories = _context.Categories.ToList(),
                Advertisements = _context.Advertisements.ToList(),
                AllInfoToProducts = _context.AllInfoToProducts.ToList(),
                ProductImages = _context.ProductImages.ToList(),
                Comments = _context.Comments.ToList(),
                Filter = Productfilter,
                AllProducts = _context.Products.ToList()
            };

            return View(model);
        }

        public IActionResult Details(int id, Comment comment)
        {
            Product product = _context.Products.Include(a=>a.AllInfoToProducts).ThenInclude(c=>c.Color).Include(c=>c.Comments).Include(d=>d.ProductDescriptions).Include(f=>f.ProductFeatures).FirstOrDefault(p=>p.Id == id);

            if (product == null)
            {
                return RedirectToAction("errorpage","home");
            }


            int[] colorIds = product.AllInfoToProducts.Select(c => c.ColorId).Distinct().ToArray();
            int[] sizeIds = product.AllInfoToProducts.Select(c => c.SizeId).Distinct().ToArray();

            Array.Sort(colorIds);
            Array.Sort(sizeIds);

            List<Color> myColors = new List<Color>();
            List<Size> mySizes = new List<Size>();

            foreach (var colorId in colorIds)
            {
                myColors.Add(_context.Colors.Where(c => c.Id == colorId).Include(a=>a.AllInfoToProducts.Where(p=>p.ProductId == id)).FirstOrDefault());
            }

            foreach (var sizeId in sizeIds)
            {
                mySizes.Add(_context.Sizes.Where(s => s.Id == sizeId).Include(a => a.AllInfoToProducts.Where(p => p.ProductId == id)).FirstOrDefault());
            }

            Comment comment1 = new Comment();
            if (comment != null)
            {
                comment1 = comment;
            }
            else
            {
                comment1 = _context.Comments.Include(u => u.CustomUser).FirstOrDefault(c => c.ProductId == id);
            }

            VmShop model = new VmShop()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                Product = product,
                Products = _context.Products.Where(c=>c.CategoryId == product.CategoryId).ToList(),
                ProductImages = _context.ProductImages.Include(c => c.Color).Where(p => p.ProductId == id).ToList(),
                ProductDescription = _context.ProductDescriptions.FirstOrDefault(p=>p.ProductId == id),
                AllInfoToProducts = _context.AllInfoToProducts.Include(sz=>sz.Size).Where(p=>p.ProductId == id).ToList(),
                Comments = _context.Comments.Where(p=>p.ProductId == id).Include(u=>u.CustomUser).ToList(),
                Comment = comment1,
                Categories = _context.Categories.ToList(),
                Colors = myColors,
                Sizes = mySizes,
                FeaturedProducts = _context.Products.ToList(),
                FeaturedAllInfoToProducts = _context.AllInfoToProducts.ToList(),
                FeaturedComments = _context.Comments.ToList(),
                FeaturedProductImages = _context.ProductImages.ToList()

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment model)
        {
            //Find User
            string userId = _userManager.GetUserId(User);
            CustomUser user = _context.CustomUsers.Find(userId);

            if (user == null)
            {
                return RedirectToAction("errorpage","home");
            }

            if (model.Text == null)
            {
                ModelState.AddModelError("Text","Review text can't be empty.");
                Notify("Review text can't be empty.", notificationType: NotificationType.error);

                return RedirectToAction("details", "shop", new { id = model.ProductId, comment = model });
            }

            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    Text = model.Text,
                    Rating = model.Rating,
                    ProductId = model.ProductId,
                    CustomUserId = userId,
                    AddedDate = DateTime.Now
                };

                _context.Comments.Add(comment);
                _context.SaveChanges();

                Notify("Your review added successfully");


                return RedirectToAction("details", "shop", new { id = model.ProductId });
            }


            return RedirectToAction("details", "shop", new { id = model.ProductId, comment = model });

        }


        public IActionResult Cart()
        {
            string cart = Request.Cookies["cart"];
            List<VmCart> allInfoToProducts = new List<VmCart>();
            allInfoToProducts.DefaultIfEmpty();

            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    VmCart prd = new VmCart();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    AllInfoToProduct prdType = _context.AllInfoToProducts.Include(p => p.Product).ThenInclude(pi => pi.ProductImages)
                                                                          .Include(p => p.Product).ThenInclude(a => a.AllInfoToProducts).FirstOrDefault(t => t.Id == id);
                    Product product = prdType.Product;

                    if (prdType == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //type id
                    prd.TypeId = prdType.Id;
                    //product id
                    prd.ProductId = prdType.Product.Id;
                    //product image
                    prd.Image = prdType.Product.ProductImages.FirstOrDefault(i => i.ColorId == prdType.ColorId).Image;
                    //product name
                    prd.Name = prdType.Product.Name;

                    //price or discount price
                    if (prdType.DiscountDeadline > DateTime.Now && prdType.DiscountPrice > 0)
                    {
                        prd.Price = prdType.DiscountPrice;
                    }
                    else
                    {
                        prd.Price = prdType.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;
                    //product max quantity
                    prd.MaxQuantity = prdType.Quantity;
                    //current color
                    prd.ColorId = prdType.ColorId;
                    //current sizes
                    prd.SizeId = prdType.SizeId;

                    //Find Suitable colorIds and sizeIds
                    List<AllInfoToProduct> siblingTypes = _context.AllInfoToProducts.Where(p => p.ProductId == prdType.ProductId && p.Quantity > 0).ToList();

                    int[] colorIds = siblingTypes.Select(c => c.ColorId).Distinct().ToArray();
                    int[] sizeIds = siblingTypes.Select(c => c.SizeId).Distinct().ToArray();

                    Array.Sort(colorIds);
                    Array.Sort(sizeIds);

                    List<Color> myColors = new List<Color>();
                    List<Size> mySizes = new List<Size>();

                    foreach (var colorId in colorIds)
                    {
                        myColors.Add(_context.Colors.Where(c => c.Id == colorId).Include(a => a.AllInfoToProducts.Where(p => p.ProductId == id)).FirstOrDefault());
                    }

                    foreach (var sizeId in sizeIds)
                    {
                        mySizes.Add(_context.Sizes.Where(s => s.Id == sizeId).Include(a => a.AllInfoToProducts.Where(p => p.ProductId == id)).FirstOrDefault());
                    }


                    ////Add products suitable colors and sizes
                    prd.Colors = myColors;
                    prd.Sizes = mySizes;

                    //Add type to product type list
                    allInfoToProducts.Add(prd);
                }
            }
            

            VmAddToCart model = new VmAddToCart()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),
                Tax = _context.Tax.FirstOrDefault(),

                Products = allInfoToProducts
            };

            return View(model);
        }

        public IActionResult Wish()
        {
            string wish = Request.Cookies["wish"];
            List<VmWish> allInfoToProducts = new List<VmWish>();
            allInfoToProducts.DefaultIfEmpty();

            if (wish != null)
            {
                List<string> prdList = wish.Split("/").ToList();

                foreach (var item in prdList)
                {
                    VmWish prd = new VmWish();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    string date = item.Split("-")[1];

                    AllInfoToProduct prdType = _context.AllInfoToProducts.Include(p => p.Product).ThenInclude(pi => pi.ProductImages)
                                                                          .Include(p => p.Product).ThenInclude(a => a.AllInfoToProducts).FirstOrDefault(t => t.Id == id);
                    Product product = prdType.Product;

                    if (prdType == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //type id
                    prd.TypeId = prdType.Id;

                    //product added date
                    prd.Date = date;

                    //product id
                    prd.ProductId = prdType.Product.Id;
                    //product image
                    prd.Image = prdType.Product.ProductImages.FirstOrDefault(i => i.ColorId == prdType.ColorId).Image;
                    //product name
                    prd.Name = prdType.Product.Name;

                    //price or discount price
                    if (prdType.DiscountDeadline > DateTime.Now && prdType.DiscountPrice > 0)
                    {
                        prd.Price = prdType.DiscountPrice;
                    }
                    else
                    {
                        prd.Price = prdType.Price;
                    }
                    //product quantity
                    prd.Quantity = prdType.Quantity;

                    //Add type to product type list
                    allInfoToProducts.Add(prd);
                }
            }

            VmAddToWish model = new VmAddToWish()
            {
                //Layout
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Universals = _context.Universal.ToList(),
                Payments = _context.Payments.ToList(),
                Contacts = _context.Contacts.ToList(),
                ContactInfo = _context.ContactInfo.FirstOrDefault(),

                //Products
                Products = allInfoToProducts,
            };

            return View(model);
        }

        public IActionResult Checkout()
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id=0, Name="Country*"});
            ViewBag.Country = countries;

            string cart = Request.Cookies["cart"];
            List<VmCheckoutProduct> allInfoToProducts = new List<VmCheckoutProduct>();
            allInfoToProducts.DefaultIfEmpty();

            decimal subtotal = 0;
            Tax tax = _context.Tax.FirstOrDefault();

            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    VmCheckoutProduct prd = new VmCheckoutProduct();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    AllInfoToProduct prdType = _context.AllInfoToProducts.Include(p => p.Product).ThenInclude(a => a.AllInfoToProducts).FirstOrDefault(t => t.Id == id);
                    Product product = prdType.Product;

                    if (prdType == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //type id
                    prd.TypeId = prdType.Id;
                   
                    //product name
                    prd.Name = prdType.Product.Name;

                    //price or discount price
                    if (prdType.DiscountDeadline > DateTime.Now && prdType.DiscountPrice > 0)
                    {
                        prd.Price = prdType.DiscountPrice;
                    }
                    else
                    {
                        prd.Price = prdType.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;
                    
                    allInfoToProducts.Add(prd);
                }

                //Calculate Subtotal
                foreach (var item in allInfoToProducts)
                {
                    subtotal += item.Price * item.Quantity;
                }

            }

            if (_signInManager.IsSignedIn(User))
            {
                //Find User
                string userId = _userManager.GetUserId(User);
                CustomUser user = _context.CustomUsers.Find(userId);

                Country userCountry = _context.Countries.Find(user.CountryId);
                decimal shippingPrice = 0;

                if (userCountry.ShippingPrice != null)
                {
                    shippingPrice = (decimal)userCountry.ShippingPrice;
                }

                VmCheckout model1 = new VmCheckout()
                {
                    //Layout
                    Setting = _context.Settings.FirstOrDefault(),
                    Socials = _context.Socials.ToList(),
                    Universals = _context.Universal.ToList(),
                    Payments = _context.Payments.ToList(),
                    Contacts = _context.Contacts.ToList(),
                    ContactInfo = _context.ContactInfo.FirstOrDefault(),
                    Tax = _context.Tax.FirstOrDefault(),

                    //SaleProduts
                    SaleProduts = allInfoToProducts,

                    //Subtotal
                    SubTotal = subtotal,

                    //Users infos return
                    CountryId = user.CountryId,
                    State = user.State,
                    Zipcode = user.ZipCode,
                    Phone = user.Phone,
                    ShippingPrice = shippingPrice

                };

                return View(model1);
            }
            else
            {
                VmCheckout model = new VmCheckout()
                {
                    //Layout
                    Setting = _context.Settings.FirstOrDefault(),
                    Socials = _context.Socials.ToList(),
                    Universals = _context.Universal.ToList(),
                    Payments = _context.Payments.ToList(),
                    Contacts = _context.Contacts.ToList(),
                    ContactInfo = _context.ContactInfo.FirstOrDefault(),

                    //SaleProduts
                    SaleProduts = allInfoToProducts,
                    Tax = _context.Tax.FirstOrDefault(),

                    //Subtotal
                    SubTotal = subtotal

                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(VmCheckout model)
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id=0, Name="Country*"});
            ViewBag.Country = countries;

            /* If Model state is not valid */
            string cart = Request.Cookies["cart"];
            if (cart == null)
            {
                return RedirectToAction("ErrorPage", "home");
            }

            List<VmCheckoutProduct> allInfoToProducts = new List<VmCheckoutProduct>();
            allInfoToProducts.DefaultIfEmpty();
            decimal subtotal = 0;
            Tax tax = _context.Tax.FirstOrDefault();
            /**************************************/

            if (model.CountryId == 0 || model.CountryId == null)
            {
                ModelState.AddModelError("CountryId", "Please select your country.");
                if (cart != null)
                {
                    List<string> prdList = cart.Split("/").ToList();

                    foreach (var item in prdList)
                    {
                        VmCheckoutProduct prd = new VmCheckoutProduct();
                        int id = Convert.ToInt32(item.Split("-")[0]);
                        int quantity = Convert.ToInt32(item.Split("-")[1]);
                        AllInfoToProduct prdType = _context.AllInfoToProducts.Include(p => p.Product).ThenInclude(a => a.AllInfoToProducts).FirstOrDefault(t => t.Id == id);
                        Product product = prdType.Product;

                        if (prdType == null)
                        {
                            return RedirectToAction("errorpage", "home");
                        }

                        //type id
                        prd.TypeId = prdType.Id;

                        //product name
                        prd.Name = prdType.Product.Name;

                        //price or discount price
                        if (prdType.DiscountDeadline > DateTime.Now && prdType.DiscountPrice > 0)
                        {
                            prd.Price = prdType.DiscountPrice;
                        }
                        else
                        {
                            prd.Price = prdType.Price;
                        }
                        //add cart product quantity
                        prd.Quantity = quantity;

                        allInfoToProducts.Add(prd);
                    }

                    //Calculate Subtotal
                    foreach (var item in allInfoToProducts)
                    {
                        subtotal += item.Price * item.Quantity;
                    }
                   
                }
                //layout
                model.Setting = _context.Settings.FirstOrDefault();
                model.Socials = _context.Socials.ToList();
                model.Universals = _context.Universal.ToList();
                model.Payments = _context.Payments.ToList();
                model.Contacts = _context.Contacts.ToList();
                model.ContactInfo = _context.ContactInfo.FirstOrDefault();
                model.SaleProduts = allInfoToProducts;
                model.SubTotal = subtotal;
                model.Tax = _context.Tax.FirstOrDefault();
                model.ShippingPrice = 0;

                return View(model);
            }


            //Shipping Price
            Country CurrentCountry = _context.Countries.FirstOrDefault(c => c.Id == model.CountryId);
            decimal? shippingPrice = CurrentCountry.ShippingPrice;

            if (shippingPrice == null)
            {
                shippingPrice = 0;
            }


            //Checkout precess
            if (ModelState.IsValid)
            {
                //Request to bank API
                //
                //
                //

                bool isBankOk = true;
                //End of API to Bank

                if (isBankOk)
                {
                    //USER CONTROL
                    if (_signInManager.IsSignedIn(User))
                    {
                        //Find User
                        string userId = _userManager.GetUserId(User);
                        CustomUser user = _context.CustomUsers.Find(userId);
                        user.CountryId = model.CountryId;
                        user.State = model.State;
                        user.ZipCode = model.Zipcode;
                        user.Phone = model.Phone;
                        _context.SaveChanges();

                        model.Name = user.Name;
                        model.Surname = user.Surname;
                        model.Email = user.Email;
                        model.Password = user.PasswordHash;
                    }
                    else
                    {
                        //First you must check this email is this customer registered before or not
                        bool CustomUser = _context.CustomUsers.Any(u => u.Email == model.Email);
                        if (CustomUser)
                        {
                            //if registered before, let for login.
                            return RedirectToAction("login", "account", new { email = model.Email, isCart = true });
                        }

                        //if user not registered
                        //Register
                        if (ModelState.IsValid)
                        {
                            var customUser = new CustomUser()
                            {
                                Name = model.Name,
                                Surname = model.Surname,
                                Email = model.Email,
                                UserName = model.Email,
                                Phone = model.Phone,
                                CountryId = model.CountryId,
                                State = model.State,
                                ZipCode = model.Zipcode

                            };
                            var result = await _userManager.CreateAsync(customUser, model.Password);


                            //Role elage elemek
                            await _userManager.AddToRoleAsync(customUser, "Customer");


                            if (result.Succeeded)
                            {
                                await _signInManager.SignInAsync(customUser, false);
                            }
                            else
                            {
                                foreach (var error in result.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                                return View(model);
                            }

                            //Automatically login
                            await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                        }

                    }

                    //SALE
                    Sale sale = new Sale();
                    Sale lastSale = _context.Sales.OrderBy(o=>o.Id).LastOrDefault();
                    //Invoice
                    //Find last sale for make invoice number unique
                    string saleInvoice = "";
                    if (lastSale != null)
                    {
                        saleInvoice ="AZ-" + (Convert.ToInt32(lastSale.InvoiceNo.Split("-")[1]) + 1);
                    }
                    else
                    {
                        saleInvoice = "AZ-1";
                    }
                    sale.InvoiceNo = saleInvoice;
                    sale.Date = DateTime.Now;

                    //Add shipping price
                    sale.ShippingPrice = (decimal)shippingPrice;

                    //for not be null after Total price will change
                    sale.TotalPrice = 0;
                    sale.CountryId = (int)model.CountryId;
                    sale.State = model.State;
                    sale.ZipCode = model.Zipcode;

                    //CustomUserId
                    //If person was login
                    if (_signInManager.IsSignedIn(User))
                    {
                        //Find User
                        string userId = _userManager.GetUserId(User);
                        CustomUser user = _context.CustomUsers.Find(userId);
                        sale.CustomUserId = user.Id;

                    }
                    else
                    {
                        //sale.CustomUserId = _context.CustomUsers.FirstOrDefault(u => u.Email == model.Email).Id;
                    }
                    _context.Sales.Add(sale);
                    _context.SaveChanges();

                    Notify("The order was successfully registered.");


                    //COOKIE
                    string cartCookie = Request.Cookies["cart"];
                    
                    List<string> prdList = cartCookie.Split("/").ToList();
                    List<VmCartCookie> cartCookies = new List<VmCartCookie>();

                    foreach (var item in prdList)
                    {
                        VmCartCookie vmCartCookie = new VmCartCookie();
                        vmCartCookie.AllInfoToProductId = Convert.ToInt32(item.Split("-")[0]);
                        vmCartCookie.Quantity = Convert.ToInt32(item.Split("-")[1]);
                        cartCookies.Add(vmCartCookie);
                    }

                    foreach (var item in cartCookies)
                    {
                        SaleItem saleItem = new SaleItem();
                        saleItem.SaleId = sale.Id;
                        saleItem.AllInfoToProductId = item.AllInfoToProductId;
                        saleItem.Quantity = item.Quantity;
                        //Find this product
                        AllInfoToProduct allInfoToProduct = _context.AllInfoToProducts.Find(item.AllInfoToProductId);
                        if (allInfoToProduct.DiscountDeadline > DateTime.Now)
                        {
                            saleItem.Price = allInfoToProduct.DiscountPrice;
                        }
                        else
                        {
                            saleItem.Price = allInfoToProduct.Price;
                        }
                        _context.SaleItems.Add(saleItem);

                        allInfoToProduct.Quantity = allInfoToProduct.Quantity - item.Quantity;
                        _context.Entry(allInfoToProduct).State = EntityState.Modified;
                        _context.SaveChanges();
                    }

                    decimal subTotal = 0;
                    decimal finalTotal = 0;

                    List<SaleItem> currentSaleItems = _context.SaleItems.Where(s => s.SaleId == sale.Id).ToList();

                    //find subtotal
                    foreach (var item in currentSaleItems)
                    {
                        subTotal += item.Price * item.Quantity;
                    }

                    //tax
                    if (subTotal < tax.PriceLimit && tax != null)
                    {
                        subTotal = subTotal + (subTotal * tax.Percent / 100);
                    }

                    //final total
                    finalTotal = subTotal;
                  

                    //***you can add final total to sale table***//

                    Sale thisSale = _context.Sales.Find(sale.Id);

                    //Shipping Price
                    finalTotal += (decimal)shippingPrice;


                    thisSale.TotalPrice = finalTotal;

                    //update Sale
                    _context.Entry(thisSale).State = EntityState.Modified;

                    //Don't change this properties
                    _context.Entry(thisSale).Property(a => a.Id).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.InvoiceNo).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.Date).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.CustomUserId).IsModified = false;

                    _context.SaveChanges();
                    
                    //Remove Cart Cookie
                    CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(-1) };
                    Response.Cookies.Append("cart", "", options);


                    return RedirectToAction("profile","account");
                }
                else
                {
                    ModelState.AddModelError("","There is a problem with your card");
                }
            }


            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    VmCheckoutProduct prd = new VmCheckoutProduct();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    AllInfoToProduct prdType = _context.AllInfoToProducts.Include(p => p.Product).ThenInclude(a => a.AllInfoToProducts).FirstOrDefault(t => t.Id == id);
                    Product product = prdType.Product;

                    if (prdType == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //type id
                    prd.TypeId = prdType.Id;

                    //product name
                    prd.Name = prdType.Product.Name;

                    //price or discount price
                    if (prdType.DiscountDeadline > DateTime.Now && prdType.DiscountPrice > 0)
                    {
                        prd.Price = prdType.DiscountPrice;
                    }
                    else
                    {
                        prd.Price = prdType.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;

                    allInfoToProducts.Add(prd);
                }

                //Calculate Subtotal
                foreach (var item in allInfoToProducts)
                {
                    subtotal += item.Price * item.Quantity;
                }


                if (shippingPrice != null && ModelState.IsValid)
                {
                    subtotal += (decimal)shippingPrice;
                }

            }

            //layout
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Universals = _context.Universal.ToList();
            model.Payments = _context.Payments.ToList();
            model.Contacts = _context.Contacts.ToList();
            model.ContactInfo = _context.ContactInfo.FirstOrDefault();
            model.SaleProduts = allInfoToProducts;
            model.SubTotal = subtotal;
            model.Tax = _context.Tax.FirstOrDefault();
            model.ShippingPrice = (decimal)shippingPrice;

            return View(model);
        }


        public JsonResult getPriceByType(int? colorId, int? sizeId, int? productId)
        {
            if (colorId== null || sizeId == null || productId == null)
            {
                return Json(404);
            }

            AllInfoToProduct productType = _context.AllInfoToProducts.FirstOrDefault(p => p.ColorId == colorId && p.SizeId == sizeId && p.ProductId == productId);

            if (productType == null)
            {
                return Json(404);
            }

            //var model = _context.AllInfoToProducts.Select(p => new
            //{
            //    p.Id,
            //    p.ColorId,
            //    p.SizeId,
            //    p.Price,
            //    p.DiscountPrice,
            //    p.Quantity,
            //    IsDiscount = productType.DiscountDeadline > DateTime.Now ? true : false

            //}).FirstOrDefault(t => t.ColorId == colorId && t.SizeId == sizeId);

            VmGetPriceByType model = new VmGetPriceByType()
            {
                Price = productType.Price,
                DiscountPrice = productType.DiscountPrice,
                Quantity = productType.Quantity,
                TypeId = productType.Id

            };

            if (productType.DiscountDeadline > DateTime.Now)
            {
                model.IsDiscount = true;
            }
            else
            {
                model.IsDiscount = false;
            }

            return Json(model);
        }

        public JsonResult getSizesByColor(int? productId, int? colorId)
        {
            if (productId == null || colorId == null)
            {
                return Json(404);
            }

            List<AllInfoToProduct> productTypes = _context.AllInfoToProducts.Include(s=>s.Size).Where(p => p.ProductId == productId && p.ColorId == colorId && p.Quantity > 0).ToList();

            if (productTypes == null)
            {
                return Json(404);
            }

            List<int> sizes = new List<int>();

            foreach (var item in productTypes)
            {
                sizes.Add(item.Size.Id);
            }


            return Json(sizes);
        }

        public JsonResult addToCart(int? typeId, int? quantity)
        {
            if (typeId == null || quantity == null)
            {
                return Json(404);
            }

            AllInfoToProduct productType = _context.AllInfoToProducts.Include(c=>c.Color).FirstOrDefault(t=>t.Id == typeId);

            if (quantity > productType.Quantity && productType.Quantity != 0)
            {
                quantity = productType.Quantity;
            }


            //if firstordefault's quantity is 0 get second product type witch quantity > 0.
            if (productType.Quantity == 0)
            {
                //main product id
                int productId = productType.ProductId;

                AllInfoToProduct secondType = _context.AllInfoToProducts.FirstOrDefault(t => t.ProductId == productId && t.Quantity > 0);
                productType = secondType;

                //second type id
                typeId = secondType.Id;

                //if quantity is bigger than our second product's quantity
                if (quantity > secondType.Quantity)
                {
                    quantity = secondType.Quantity;
                }

            }

            if (productType == null)
            {
                return Json(404);
            }

            int count = 1;
            bool IsExist = false;

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];


                List<string> prdList = oldCart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == typeId)
                    {
                        IsExist = true;
                        //Notify("This product already exist in the cart!", notificationType: NotificationType.error);
                        break;

                    }
                }

                if (!IsExist)
                {
                    count = Request.Cookies["cart"].Split("/").Count() + 1;

                    string newPrd = typeId + "-" + quantity;
                    string newCart = oldCart + "/" + newPrd;
                    Response.Cookies.Append("cart", newCart, options);
                }
                else
                {
                    //count = Request.Cookies["cart"].Split("/").Count();
                    count = -404;
                }


            }
            else
            {
                Response.Cookies.Append("cart", "" + typeId + "-"+ quantity + "", options);
            }

            return Json(count);
        }

        public JsonResult addToWish(int? typeId)
        {
            if (typeId == null)
            {
                return Json(404);
            }

            AllInfoToProduct productType = _context.AllInfoToProducts.FirstOrDefault(t => t.Id == typeId);

            if (productType == null)
            {
                return Json(404);
            }

            int count = 1;
            bool IsExist = false;

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["wish"] != null)
            {
                string oldCart = Request.Cookies["wish"];


                List<string> prdList = oldCart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == typeId)
                    {
                        IsExist = true;
                        break;
                    }
                }

                if (!IsExist)
                {
                    count = Request.Cookies["wish"].Split("/").Count() + 1;
                    string date = (DateTime.Now).ToString("dd.MM.yyyy");
                    string newPrd = typeId + "-" + date;
                    string newCart = oldCart + "/" + newPrd;
                    Response.Cookies.Append("wish", newCart, options);
                }
                else
                {
                    count = Request.Cookies["wish"].Split("/").Count();
                    return Json(-404);
                }


            }
            else
            {
                string date = (DateTime.Now).ToString("dd.MM.yyyy");
                Response.Cookies.Append("wish", "" + typeId + "-" + date + "", options);
            }

            return Json(count);
        }

        public JsonResult RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return Json(404);
            }

            AllInfoToProduct productType = _context.AllInfoToProducts.FirstOrDefault(t => t.Id == id);

            if (productType == null)
            {
                return Json(404);
            }


            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                string prd = null;

                foreach (var item in prdList)
                {
                    Convert.ToInt32(item.Split("-")[0]);
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        prd = item;
                        break;
                    }
                }
                if (prd != null)
                {
                    prdList.Remove(prd);
                    string newCard = null;
                    foreach (var item in prdList)
                    {
                        if (item == prdList[prdList.Count - 1])
                        {
                            newCard += item;
                        }
                        else
                        {
                            newCard += item + "/";
                        }
                    }
                    if (newCard != null)
                    {
                        Response.Cookies.Append("cart", newCard, options);
                    }
                    else
                    {
                        options.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Append("cart", "", options);

                    }

                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }

        public JsonResult RemoveFromWish(int? id)
        {
            if (id == null)
            {
                return Json(404);
            }

            AllInfoToProduct productType = _context.AllInfoToProducts.FirstOrDefault(t => t.Id == id);

            if (productType == null)
            {
                return Json(404);
            }

            int count = 0;

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };

            if (Request.Cookies["wish"] != null)
            {
                string oldWish = Request.Cookies["wish"];
                List<string> prdList = oldWish.Split("/").ToList();
                string prd = null;
                count = prdList.Count;

                foreach (var item in prdList)
                {
                    Convert.ToInt32(item.Split("-")[0]);
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        prd = item;
                        break;
                    }
                }
                if (prd != null)
                {
                    prdList.Remove(prd);
                    string newWish = null;
                    foreach (var item in prdList)
                    {
                        if (item == prdList[prdList.Count - 1])
                        {
                            newWish += item;
                        }
                        else
                        {
                            newWish += item + "/";
                        }
                    }
                    if (newWish != null)
                    {
                        Response.Cookies.Append("wish", newWish, options);
                    }
                    else
                    {
                        options.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Append("wish", "", options);

                    }

                }
            }
            else
            {
                return Json(404);
            }

            if (count == 1)
            {
                return Json(100);
            }

            return Json(200);
        }


        public JsonResult UpdateCart(int? id, int? quantity)
        {
            if (id == null || quantity == null)
            {
                return Json(404);
            }

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };
            int indexOfPrd = 0;

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    Convert.ToInt32(item.Split("-")[0]);
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        indexOfPrd = prdList.IndexOf(item);
                        break;
                    }
                }

                int iteration = 0;

                //Append new quentity to product
                prdList[indexOfPrd] = id + "-" + quantity;

                string newCard = null;
                foreach (var item in prdList)
                {
                    if (item == prdList[prdList.Count - 1])
                    {
                        if (iteration != prdList.Count - 1)
                        {
                            newCard += item + "/";
                        }
                        else
                        {
                            newCard += item;
                        }
                    }
                    else
                    {
                        newCard += item + "/";
                    }
                    iteration++;
                }

                if (newCard != null)
                {
                    Response.Cookies.Append("cart", newCard, options);
                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }

        public JsonResult UpdateColorCart(int? typeId, int? colorId, int? quantity)
        {
            if (typeId == null || colorId == null || quantity == null)
            {
                return Json(404);
            }

            AllInfoToProduct oldPrdType = _context.AllInfoToProducts.Find(typeId);

            if (oldPrdType == null)
            {
                return Json(404);
            }

            AllInfoToProduct newPrdType = _context.AllInfoToProducts.FirstOrDefault(t=>t.ProductId == oldPrdType.ProductId && t.ColorId ==colorId  && t.Quantity > 0);

            if (quantity > newPrdType.Quantity)
            {
                quantity = newPrdType.Quantity;
            }

            if (newPrdType == null)
            {
                return Json(404);
            }

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };
            int indexOfPrd = 0;



            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == typeId)
                    {
                        indexOfPrd = prdList.IndexOf(item);
                        break;
                    }
                }

                int iteration = 0;

                //Append new quentity to product
                prdList[indexOfPrd] = newPrdType.Id + "-" + quantity;

                string newCard = null;
                foreach (var item in prdList)
                {
                    if (item == prdList[prdList.Count-1])
                    {
                        if (iteration != prdList.Count - 1)
                        {
                            newCard += item + "/";
                        }
                        else
                        {
                            newCard += item;
                        }

                    }
                    else
                    {
                        newCard += item + "/";
                    }

                    iteration++;
                }

                if (newCard != null)
                {
                    Response.Cookies.Append("cart", newCard, options);
                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }

        public JsonResult UpdateSizeCart(int? typeId, int? sizeId, int? quantity)
        {
            if (typeId == null || sizeId == null || quantity == null)
            {
                return Json(404);
            }

            AllInfoToProduct oldPrdType = _context.AllInfoToProducts.Find(typeId);

            if (oldPrdType == null)
            {
                return Json(404);
            }

            AllInfoToProduct newPrdType = _context.AllInfoToProducts.FirstOrDefault(t => t.ProductId == oldPrdType.ProductId && t.SizeId == sizeId && t.ColorId == oldPrdType.ColorId && t.Quantity > 0);

            if (quantity > newPrdType.Quantity)
            {
                quantity = newPrdType.Quantity;
            }

            if (newPrdType == null)
            {
                return Json(404);
            }

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };
            int indexOfPrd = 0;



            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == typeId)
                    {
                        indexOfPrd = prdList.IndexOf(item);
                        break;
                    }
                }

                int iteration = 0;

                //Append new quentity to product
                prdList[indexOfPrd] = newPrdType.Id + "-" + quantity;

                string newCard = null;
                foreach (var item in prdList)
                {
                    if (item == prdList[prdList.Count - 1])
                    {
                        if (iteration != prdList.Count - 1)
                        {
                            newCard += item + "/";
                        }
                        else
                        {
                            newCard += item;
                        }

                    }
                    else
                    {
                        newCard += item + "/";
                    }

                    iteration++;
                }

                if (newCard != null)
                {
                    Response.Cookies.Append("cart", newCard, options);
                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }

        public JsonResult getToCartCount()
        {
            int count = 0;

            if (Request.Cookies["cart"] != null)
            {
                count = Request.Cookies["cart"].Split("/").Count();
            }

            return Json(count);
        }

        public JsonResult getToCartSum()
        {
            decimal sum = 0;

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    int typeid = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);

                    AllInfoToProduct allInfoToProduct = _context.AllInfoToProducts.Find(typeid);

                    if (allInfoToProduct == null)
                    {
                        Notify("There is error with cart items!", notificationType: NotificationType.error);
                        return Json(0);
                    }

                    if (allInfoToProduct.DiscountDeadline > DateTime.Now && allInfoToProduct.Quantity > 0)
                    {
                        sum += allInfoToProduct.DiscountPrice * quantity;
                    }
                    else
                    {
                        sum += allInfoToProduct.Price * quantity;
                    }
                }

                //if less 100$ add tax 18%
                Tax tax = _context.Tax.FirstOrDefault();

                if (sum < tax.PriceLimit)
                {
                    sum = sum + (sum * tax.Percent / 100);
                }
            }
            else
            {
                return Json(0);
            }


            return Json(sum);
        }

        public JsonResult getToWishCount()
        {
            int count = 0;

            if (Request.Cookies["wish"] != null)
            {
                count = Request.Cookies["wish"].Split("/").Count();
            }

            return Json(count);
        }

        public JsonResult getShippingPrice(int? countryId)
        {
            if (countryId == null)
            {
                return Json(-404);
            }

            Country country = _context.Countries.FirstOrDefault(c => c.Id == countryId);

            if (country == null)
            {
                return Json(-404);
            }

            decimal? shippingPrice = country.ShippingPrice;

            if (shippingPrice == null)
            {
                shippingPrice = 0;
            }

            return Json(shippingPrice);
        }


    }
}
