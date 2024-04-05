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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the one-to-many relationship between ShoppingCart and CartItem
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(c => c.CartItems)
                .WithOne() // Assuming no navigation property back to ShoppingCart in CartItem
                .HasForeignKey(ci => ci.ShoppingCartId) // Ensure CartItem class has a ShoppingCartId property
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete items when a ShoppingCart is deleted

            // Any other custom model configurations go here
        }
    }
}
