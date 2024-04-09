using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Applikation_med_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Override the OnModelCreating method
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<CartItem>()
        //        .HasOne(ci => ci.ShoppingCart)
        //        .WithMany(s => s.CartItems)
        //        .HasForeignKey(ci => ci.ShoppingCartId)
        //        .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 4); // Example: 18 total digits, 4 of which are after the decimal point
        }





    }
}
