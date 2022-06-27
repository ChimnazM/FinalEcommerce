using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopwise.Data;
using Shopwise.Models;
using Shopwise.ViewModels;

namespace Shopwise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Accountant")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            int today = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            List<Sale> sales = _context.Sales.ToList();
            List<Sale> todaySales = _context.Sales.Include(s=>s.SaleItems).Where(d=>d.Date.Day == today && d.Date.Month == month & d.Date.Year == year).ToList();
            List<Sale> currentMonthSales = _context.Sales.Where(d=>d.Date.Month == month & d.Date.Year == year).ToList();
            int todayOrderCount = todaySales.Count;
            int monthOrderCount = currentMonthSales.Count;

            //Total Revenue for today
            decimal todaytotalRevenue = 0;
            int todaySaleItemsCount = 0;


            //Today best seller
            List<SaleItem> todaySaleItems = new List<SaleItem>();
            SaleItem todayBestSellerSaleItem = new SaleItem();
            Product todayBestSellerProduct = new Product();
            decimal todayRevenueBestSeller = 0;


            if (todaySales.Count != 0)
            {
                foreach (var item in todaySales)
                {
                    todaytotalRevenue += item.TotalPrice;
                }

                //Today Sale items Count
                foreach (var item in todaySales)
                {
                    todaySaleItemsCount += item.SaleItems.Count;
                }

                //Today's Best Seller
                List<int> quantities = new List<int>();
                foreach (var sale in todaySales)
                {
                    List<SaleItem> saleItemsForOneSale = _context.SaleItems.Include(sa=>sa.Sale).Include(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product).Include(a => a.AllInfoToProduct).ThenInclude(c => c.Color).Include(a => a.AllInfoToProduct).ThenInclude(s => s.Size).Where(s => s.SaleId == sale.Id && s.Sale.Date.Day == today).ToList();

                    foreach (var item in saleItemsForOneSale)
                    {
                        todaySaleItems.Add(item);
                    }
                }

                foreach (var saleItem in todaySaleItems)
                {
                    quantities.Add(saleItem.Quantity);
                }

                if (quantities != null  && quantities[0] != 0)
                {
                    //max quantity
                    int maxQuantity = quantities.Max();
                    //this is a today's best seller saleitem.
                    todayBestSellerSaleItem = todaySaleItems.FirstOrDefault(q => q.Quantity == maxQuantity);
                    todayBestSellerProduct = todayBestSellerSaleItem.AllInfoToProduct.Product;

                    foreach (var saleItem in todaySaleItems)
                    {
                        if (saleItem.AllInfoToProductId == todayBestSellerSaleItem.AllInfoToProductId)
                        {
                            //today revenue
                            todayRevenueBestSeller += saleItem.Price * saleItem.Quantity;
                        }
                    }
                }

            }


            //Month best seller
            List<SaleItem> monthSaleItems = new List<SaleItem>();
            SaleItem monthBestSellerSaleItem = new SaleItem();
            Product monthBestSellerProduct = new Product();
            //Best seller product's total revenue
            decimal monthRevenueBestSeller = 0;

            if (currentMonthSales.Count != 0)
            {
                foreach (var sale in currentMonthSales)
                {
                    List<SaleItem> saleItemsForOneSale = _context.SaleItems.Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Include(a => a.AllInfoToProduct).ThenInclude(c => c.Color).Include(a => a.AllInfoToProduct).ThenInclude(s => s.Size).Include(sa=>sa.Sale).Where(s => s.SaleId == sale.Id && s.Sale.Date.Month == month).ToList();

                    foreach (var item in saleItemsForOneSale)
                    {
                        monthSaleItems.Add(item);
                    }
                }

                //Saleitems quantities
                List<int> quantities = new List<int>();
                

                foreach (var saleItem in monthSaleItems)
                {
                    quantities.Add(saleItem.Quantity);
                    
                }

                if (quantities != null && quantities[0] != 0)
                {
                    //max quantity
                    int maxQuantity = quantities.Max();
                    //this is a today's best seller saleitem.
                    monthBestSellerSaleItem = monthSaleItems.FirstOrDefault(q => q.Quantity == maxQuantity);
                    monthBestSellerProduct = monthBestSellerSaleItem.AllInfoToProduct.Product;

                    foreach (var saleItem in monthSaleItems)
                    {
                        if (saleItem.AllInfoToProductId == monthBestSellerSaleItem.AllInfoToProductId)
                        {
                            //test
                            monthRevenueBestSeller += saleItem.Price * saleItem.Quantity;
                        }
                    }
                }
            }


            VmAdmin model = new VmAdmin()
            {
                todayOrderCount = todayOrderCount,
                monthOrderCount = monthOrderCount,
                todaytotalRevenue = todaytotalRevenue,
                todaySaleItemsCount = todaySaleItemsCount,
                todayBestSellerSaleItem = todayBestSellerSaleItem,
                todayBestSellerProduct = todayBestSellerProduct,
                monthBestSellerSaleItem = monthBestSellerSaleItem,
                monthBestSellerProduct = monthBestSellerProduct,
                monthRevenueBestSeller = monthRevenueBestSeller,
                todayRevenueBestSeller = todayRevenueBestSeller

            };


            return View(model);
        }

        public JsonResult getSalesByCategories()
        {
            int today = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            List<Sale> monthSales = _context.Sales.Include(a=>a.SaleItems).ThenInclude(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product).Where(d => d.Date.Month == month).ToList();
            List<SaleItem> monthSaleItems = new List<SaleItem>();

            foreach (var sale in monthSales)
            {
                List<SaleItem> saleItemsForOneSale = sale.SaleItems.ToList();

                foreach (var item in saleItemsForOneSale)
                {
                    monthSaleItems.Add(item);
                }
            }

            List<SaleItem> bestSaleItems = _context.SaleItems.Include(s=>s.Sale).Include(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product).Where(s => s.AllInfoToProduct.Product.CategoryId == 1 && s.Sale.Date.Month == month).ToList();
            List<SaleItem> featuredItems = _context.SaleItems.Include(s => s.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.AllInfoToProduct.Product.CategoryId == 2 && s.Sale.Date.Month == month).ToList();
            List<SaleItem> newArrivalSaleItems = _context.SaleItems.Include(s => s.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.AllInfoToProduct.Product.CategoryId == 3 && s.Sale.Date.Month == month).ToList();
            List<SaleItem> specialOfferSaleItems = _context.SaleItems.Include(s => s.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.AllInfoToProduct.Product.CategoryId == 4 && s.Sale.Date.Month == month).ToList();

            int allSaleItems = monthSaleItems.Count();
            int bestSellerPercent = bestSaleItems.Count();
            int featuredPercent = featuredItems.Count();
            int newArrivalPercent = newArrivalSaleItems.Count();
            int specialOfferPercent = specialOfferSaleItems.Count();

            VmSaleByCategory model = new VmSaleByCategory(){
                AllSaleItemsCount = allSaleItems,
                BestSellerCount = bestSellerPercent,
                FeaturedCount = featuredPercent,
                NewArrivalCount = newArrivalPercent,
                SpecialOfferCount = specialOfferPercent
            };

            return Json(model);
        }

        public JsonResult getSalesByGender()
        {
            int today = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            List<Sale> monthSales = _context.Sales.Include(s=>s.SaleItems).ThenInclude(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product).Where(d => d.Date.Month == month).ToList();
            List<SaleItem> monthSaleItems = new List<SaleItem>();

            foreach (var sale in monthSales)
            {
                List<SaleItem> saleItemsForOneSale = sale.SaleItems.ToList();

                foreach (var item in saleItemsForOneSale)
                {
                    monthSaleItems.Add(item);
                }
            }

            List<SaleItem> maleSaleItems = monthSaleItems.Where(s => s.AllInfoToProduct.Product.GenderId == 1).ToList();
            List<SaleItem> femaleSaleItems = monthSaleItems.Where(s => s.AllInfoToProduct.Product.GenderId == 2).ToList();
            List<SaleItem> kidsSaleItems = monthSaleItems.Where(s => s.AllInfoToProduct.Product.GenderId == 3).ToList();

            int AllItemsCount = monthSaleItems.Count();
            int maleSaleItemsCount = maleSaleItems.Count();
            int femaleSaleItemsCount = femaleSaleItems.Count();
            int kidsSaleItemsCount = kidsSaleItems.Count();

            VmSalesByGender model = new VmSalesByGender()
            {
                AllSaleItemsCount = AllItemsCount,
                MaleSaleItemsCount = maleSaleItemsCount,
                FemaleSaleItemsCount = femaleSaleItemsCount,
                KidsSaleItemsCount = kidsSaleItemsCount
            };

            return Json(model);
        }

        public JsonResult getStatisticsCategories()
        {
            int year = DateTime.Now.Year;

            List<SaleItem> januarySaleItems = _context.SaleItems.Include(sa=>sa.Sale).Include(a=>a.AllInfoToProduct).ThenInclude(p=>p.Product).Where(s=>s.Sale.Date.Month == 1 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> februarySaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 2 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> marchSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 3 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> aprilSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 4 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> maySaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 5 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> juneSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 6 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> julySaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 7 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> augustSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 8 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> septemberSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 9 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> octoberSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 10 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> novemberSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 11 && s.Sale.Date.Year == year).ToList();
            List<SaleItem> decemberSaleItems = _context.SaleItems.Include(sa => sa.Sale).Include(a => a.AllInfoToProduct).ThenInclude(p => p.Product).Where(s => s.Sale.Date.Month == 12 && s.Sale.Date.Year == year).ToList();


            List<int> januarySalesCountList = GetMonthList(januarySaleItems);
            List<int> februarySalesCountList = GetMonthList(februarySaleItems);
            List<int> marchSalesCountList = GetMonthList(marchSaleItems);
            List<int> aprilSalesCountList = GetMonthList(aprilSaleItems);
            List<int> maySalesCountList = GetMonthList(maySaleItems);
            List<int> juneSalesCountList = GetMonthList(juneSaleItems);
            List<int> julySalesCountList = GetMonthList(julySaleItems);
            List<int> augustSalesCountList = GetMonthList(augustSaleItems);
            List<int> septemberSalesCountList = GetMonthList(septemberSaleItems);
            List<int> octoberSalesCountList = GetMonthList(octoberSaleItems);
            List<int> novemberSalesCountList = GetMonthList(novemberSaleItems);
            List<int> decemberSalesCountList = GetMonthList(decemberSaleItems);

            VmStatisticsCategory model = new VmStatisticsCategory()
            {
                Jan = januarySalesCountList,
                Feb = februarySalesCountList,
                Mar = marchSalesCountList,
                Apr = aprilSalesCountList,
                May = maySalesCountList,
                Jun = juneSalesCountList,
                Jul = julySalesCountList,
                Aug = augustSalesCountList,
                Sep = septemberSalesCountList,
                Oct = octoberSalesCountList,
                Nov = novemberSalesCountList,
                Dec = decemberSalesCountList
            };

            return Json(model);
        }

        public List<int> GetMonthList(List<SaleItem> saleItems)
        {
            List<int> SalesCountList = new List<int>();

            if (saleItems.Count != 0)
            {
                List<SaleItem> BestSeller = saleItems.Where(b => b.AllInfoToProduct.Product.CategoryId == 1).ToList();
                List<SaleItem> Featured = saleItems.Where(b => b.AllInfoToProduct.Product.CategoryId == 2).ToList();
                List<SaleItem> NewArrival = saleItems.Where(b => b.AllInfoToProduct.Product.CategoryId == 3).ToList();
                List<SaleItem> SpecialOffer = saleItems.Where(b => b.AllInfoToProduct.Product.CategoryId == 4).ToList();

                return SalesCountList = new List<int> { BestSeller.Count, Featured.Count, NewArrival.Count, SpecialOffer.Count };
            }
            else
            {
                return SalesCountList = new List<int> { 0, 0, 0, 0 };
            }
        }

        public IActionResult Game()
        {
            return View();
        }
    }
}
