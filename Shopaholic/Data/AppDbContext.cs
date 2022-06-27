using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopwise.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChooseUs> ChooseUs { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<AllInfoToProduct> AllInfoToProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MissionFeature> MissionFeatures { get; set; }
        public DbSet<MissionFile> MissionFiles { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<Universal> Universal { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Universal> Universals { get; set; }


    }
}
