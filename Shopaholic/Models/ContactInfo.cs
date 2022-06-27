﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }

        [MaxLength(4000)]
        public string Map { get; set; }
    }
}
