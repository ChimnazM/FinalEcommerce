using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public string CustomUserId { get; set; }
        [ForeignKey("CustomUserId")]
        public CustomUser CustomUser { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingPrice { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [MaxLength(250)]
        public string State { get; set; }


        [MaxLength(250)]
        public string ZipCode { get; set; }

        public List<SaleItem> SaleItems { get; set; }
    }
}
