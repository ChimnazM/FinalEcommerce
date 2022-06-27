using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N3}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingPrice { get; set; }

        public List<CustomUser> CustomUsers { get; set; }
        public List<Sale> Sales { get; set; }
        

    }
}
