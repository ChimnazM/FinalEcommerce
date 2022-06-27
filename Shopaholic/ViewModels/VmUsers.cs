using Microsoft.AspNetCore.Identity;
using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Shopwise.ViewModels
{
    public class VmUsers
    {
        public List<CustomUser> CustomUsers { get; set; }
        public List<IdentityUserRole<string>> UserRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
