using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmInvoice : VmBase
    {
        public bool isPdf { get; set; }
        public Sale Sale { get; set; }
        public List<SaleItem> SaleItems { get; set; }

        public decimal Subtotal { get; set; }
    }
}
