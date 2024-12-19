using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.Entities;


namespace VristoAPI.Infrastructure.Database
{
    public class DataContext : IdentityDbContext
    {
        public DataContext()  { }
        public DataContext(DbContextOptions<DataContext> opt):base(opt) { }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().HasIndex(a => a.UserName);
            builder.Entity<CartProducts>().HasKey(a => new { a.ProductID, a.CartID });
            builder.Entity<OrderProducts>().HasKey(a => new { a.ProductID, a.OrderID });
            
        }
      
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cart> Carts { get; set; }


        public DbSet<Offers> Offers {get;set;}


        public DbSet<Product> Products { get; set; }    

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }

        public DbSet<CartProducts> CartProducts { get; set; }

        public DbSet<OrderProducts>OrderProducts { get; set; }
         

        public DbSet<Invoice> Invoices { get; set; }


    }
}
