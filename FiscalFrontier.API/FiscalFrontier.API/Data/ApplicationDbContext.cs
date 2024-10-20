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
        public DbSet<AccountUpdateHistory> AccountUpdatesHistories { get; set; }
        public DbSet<AccountNumbers> AccountNumbers { get; set; }
        public DbSet<FileRecord> FileRecords { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Credit> Credits { get; set; }



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

            modelBuilder.Entity<Debit>().
                HasOne(d => d.JournalEntry)
                .WithMany(j => j.Debits)
                .HasForeignKey(d => d.JournalEntryId);

            modelBuilder.Entity<Credit>()
                .HasOne(c => c.JournalEntry)
                .WithMany(j => j.Credits)
                .HasForeignKey(c => c.JournalEntryId);
            modelBuilder.Entity<FileRecord>()
                .HasOne(f => f.JournalEntry)
                .WithMany(j => j.Files)
                .HasForeignKey(f => f.JournalEntryId);
        }
    }
}
