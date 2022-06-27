using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }

        public DateTime AddedDate { get; set; }

        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductDescription> ProductDescriptions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<AllInfoToProduct> AllInfoToProducts { get; set; }
    }
}
