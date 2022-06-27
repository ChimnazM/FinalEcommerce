﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        public string Name { get; set; }
        public List<AllInfoToProduct> AllInfoToProducts { get; set; }
    }
}
