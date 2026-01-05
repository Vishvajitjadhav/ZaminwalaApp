using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Infrastructure.Data
{
    public class ProjectZDbContext : DbContext
    {
        public ProjectZDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<SellerStatus> SellerStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PropertyVisit> PropertyVisits { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<OTP> OTPs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configuration for User and Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, Name = "Residential" },
                new PropertyType { Id = 2, Name = "Commercial" },
                new PropertyType { Id = 3, Name = "Villa/Bungalow" }
               );
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Seller) // Property links to Seller (User)
                .WithMany(u => u.Properties) // A Seller (User) can have multiple Properties
                .HasForeignKey(p => p.SellerId) // Foreign key is SellerId in Property
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
