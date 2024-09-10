using FiscalFrontier.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, roleName = "Administrator" },
                new Role { Id = 2, roleName = "Manager" },
                new Role { Id = 3, roleName = "Accountant" }
                );
        }
    }
}
