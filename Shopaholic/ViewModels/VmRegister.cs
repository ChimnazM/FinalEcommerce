using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmRegister : VmBase
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [Required, MaxLength(250)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Password { get; set; }

        [Required, MaxLength(30)]
        public string ConfirmPassword { get; set; }
    }
}
