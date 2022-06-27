﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string CustomUserFullname { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
