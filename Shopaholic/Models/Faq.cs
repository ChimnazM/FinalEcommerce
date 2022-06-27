using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Question { get; set; }

        [MaxLength(2000)]
        public string Answer { get; set; }

        public bool IsGeneral { get; set; }
    }
}
