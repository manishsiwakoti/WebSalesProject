using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesProject.Models;

namespace WebSalesProject.Data
    {
    public class SalesDbContext : DbContext
        {
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestLine> RequestLines { get; set; }
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {

            }
        protected override void OnModelCreating(ModelBuilder model)
            {
            model.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.UserName).IsUnique();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
                e.Property(x => x.LastName).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.IsReviewer).IsRequired();
                e.Property(x => x.IsAdmin).IsRequired();
                e.Property(x => x.UserName).HasMaxLength(30).IsRequired();

            });
            model.Entity<Vendor>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Code).IsUnique();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Address).HasMaxLength(30).IsRequired();
                e.Property(x => x.State).HasMaxLength(2).IsRequired();
                e.Property(x => x.City).HasMaxLength(30).IsRequired();
                e.Property(x => x.Zip).HasMaxLength(5).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.Code).HasMaxLength(30).IsRequired();

            });
            model.Entity<Product>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price).HasColumnType("decimal(11,2)");
                e.Property(x => x.Unit).HasMaxLength(30).IsRequired();
                e.Property(x => x.Photopath).HasMaxLength(255);
                
            });
            model.Entity<Request>(e => {
                e.HasKey(x => x.Id);
                e.Property(x => x.Description).HasMaxLength(80).IsRequired();
                e.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                e.Property(x => x.RejectionReason).HasMaxLength(80);
                e.Property(x => x.DeliveryMode).HasMaxLength(20).IsRequired().HasDefaultValue("Pickup");
                e.Property(x => x.Status).HasMaxLength(10).IsRequired().HasDefaultValue("NEW");
                e.Property(x => x.Total).HasColumnType("decimal(11,2)");
            });

            model.Entity<RequestLine>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.RequestId);
                e.Property(x => x.ProductId);


            });
            }
        public DbSet<WebSalesProject.Models.RequestLine> RequestLine { get; set; }
             
            }

        }
   


