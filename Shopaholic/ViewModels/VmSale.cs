using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmSale
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Tax { get; set; }
        public string ShippingCountry { get; set; }

        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public string CustomUserFullName { get; set; }
        public DateTime Date { get; set; }
    }
}
