using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string HeaderLogo { get; set; }

        [MaxLength(250)]
        public string FooterLogo { get; set; }

        [MaxLength(1000)]
        public string About { get; set; }

        [NotMapped]
        public IFormFile HeaderImageFile { get; set; }

        [NotMapped]
        public IFormFile FooterImageFile { get; set; }
    }
}
