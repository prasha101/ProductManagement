using Microsoft.EntityFrameworkCore;
using ProductApplication.Models;
using System.Collections.Generic;

namespace ProductApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
        }
    }
    
}
