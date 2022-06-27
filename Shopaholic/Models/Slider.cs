using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(250)]
        public string UpTitle { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
