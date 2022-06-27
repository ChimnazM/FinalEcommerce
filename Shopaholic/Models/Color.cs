using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }


        public List<AllInfoToProduct> AllInfoToProducts { get; set; }
        
        public List<ProductImage> ProductImages { get; set; }
    }
}
