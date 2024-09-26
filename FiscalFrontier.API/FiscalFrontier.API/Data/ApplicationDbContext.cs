using FiscalFrontier.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
        public DbSet<UserCreationRequest> UserCreationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SecurityQuestions>().HasData(
                new SecurityQuestions { securityQuestionId = 1, securityQuestion= "What was the first exam you failed?" },
                new SecurityQuestions { securityQuestionId = 2, securityQuestion = "What was your Mother/Father's first car brand?" },
                new SecurityQuestions { securityQuestionId = 3, securityQuestion = "What was the name of your siblings favorite stuffed animal?" },
                new SecurityQuestions { securityQuestionId = 4, securityQuestion = "In what city was your Grandmother or Grandfather born?" }
                );

            modelBuilder.Entity<UserSecurityQuestion>()
                .HasOne(u => u.user)
                .WithMany(u => u.securityQuestions)
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserSecurityQuestion>()
                .HasOne(s => s.securityQuestion)
                .WithMany()
                .HasForeignKey(s => s.securityQuestionId);
            

        }
    }
}
