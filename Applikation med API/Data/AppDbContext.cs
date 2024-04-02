using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Applikation_med_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
