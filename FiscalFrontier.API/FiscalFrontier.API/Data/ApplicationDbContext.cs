using FiscalFrontier.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserCreationRequest> UserCreationRequests { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChartOfAccount>()
                .HasIndex(a => a.accountNumber)
                .IsUnique();

            modelBuilder.Entity<ChartOfAccount>()
                .HasIndex(a => a.accountName)
                .IsUnique();

            modelBuilder.Entity<ChartOfAccount>()
                .Property(a => a.accountInitialBalance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ChartOfAccount>()
                .Property(a => a.accountDebit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ChartOfAccount>()
                .Property(a => a.accountCredit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ChartOfAccount>()
                .Property(a => a.accountBalance)
                .HasColumnType("decimal(18,2)");
        }
    }
}
