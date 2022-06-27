using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmCart
    {
        public int ProductId { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MaxQuantity { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }


        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }

    }
}
