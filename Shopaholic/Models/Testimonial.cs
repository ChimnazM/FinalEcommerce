using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string UpTitle { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Info { get; set; }
    }
}
