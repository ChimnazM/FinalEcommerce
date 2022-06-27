using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CustomUserId { get; set; }
        [ForeignKey("CustomUserId")]
        public CustomUser CustomUser { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }
        public int Rating { get; set; }


        public DateTime AddedDate { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
