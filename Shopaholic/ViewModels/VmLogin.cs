using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmLogin : VmBase
    {
        [Required, MaxLength(250)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Password { get; set; }
        public bool? isCart { get; set; }
    }
}
