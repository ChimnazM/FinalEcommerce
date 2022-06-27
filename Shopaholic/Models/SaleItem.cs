using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }

        public int AllInfoToProductId { get; set; }
        [ForeignKey("AllInfoToProductId")]
        public AllInfoToProduct AllInfoToProduct { get; set; }

        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
