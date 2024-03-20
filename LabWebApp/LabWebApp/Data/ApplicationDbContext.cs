using LabWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LabWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        // DbSet property for the Product entity
        public DbSet<Product> Products { get; set; }
        public DbSet<LabWebApp.Models.Category> Category { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}



