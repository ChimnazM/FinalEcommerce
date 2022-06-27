using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmAddToCart : VmBase
    {
        public List<VmCart> Products { get; set; }
        public Tax Tax { get; set; }
    }
}
