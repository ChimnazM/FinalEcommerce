using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.ViewModels
{
    public class VmCheckout : VmBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [Required, MaxLength(250)]
        public string State { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(10)]
        public string Zipcode { get; set; }

        [Required]
        public int? CountryId { get; set; }

        //Properties for cad infos
        [Required, MaxLength(250)]
        public string CardName { get; set; }

        [Required, MaxLength(19)]
        public string CardNumber { get; set; }

        [Required, MaxLength(5)]
        public string CardDate { get; set; }

        [Required, MaxLength(3)]
        public string SecurityCode { get; set; }

        public List<VmCheckoutProduct> SaleProduts { get; set; }
        public decimal SubTotal { get; set; }
        public Tax Tax { get; set; }

        public decimal ShippingPrice { get; set; }

    }
}
