using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmBase
    {
        public Setting Setting { get; set; }
        public List<Social> Socials { get; set; }
        public List<Contact> Contacts { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Universal> Universals { get; set; }
    }
}
