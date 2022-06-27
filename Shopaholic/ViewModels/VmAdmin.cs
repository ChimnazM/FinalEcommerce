using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmAdmin
    {
        public List<Sale> AllSales { get; set; }
        public List<Sale> TodaySales { get; set; }
        public List<Sale> MonthSales { get; set; }
        public int todayOrderCount { get; set; }
        public int todaySaleItemsCount { get; set; }
        public int monthOrderCount { get; set; }
        public decimal todaytotalRevenue { get; set; }
        public SaleItem todayBestSellerSaleItem { get; set; }
        public SaleItem monthBestSellerSaleItem { get; set; }
        public Product todayBestSellerProduct { get; set; }
        public Product monthBestSellerProduct { get; set; }
        public decimal todayRevenueBestSeller { get; set; }
        public decimal monthRevenueBestSeller { get; set; }
    }
}
