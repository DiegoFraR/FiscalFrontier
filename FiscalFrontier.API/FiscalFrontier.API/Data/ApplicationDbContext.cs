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
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { roleId = 1, roleName = "Administrator" },
                new Role { roleId = 2, roleName = "Manager" },
                new Role { roleId = 3, roleName = "Accountant" }
                );

            modelBuilder.Entity<SecurityQuestions>().HasData(
                new SecurityQuestions { securityQuestionId = 1, securityQuestion= "What was the first exam you failed?" },
                new SecurityQuestions { securityQuestionId = 2, securityQuestion = "What was your Mother/Father's first car brand?" },
                new SecurityQuestions { securityQuestionId = 3, securityQuestion = "What was the name of your siblings favorite stuffed animal?" },
                new SecurityQuestions { securityQuestionId = 4, securityQuestion = "In what city was your Grandmother or Grandfather born?" }
                );

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "dFrausto0924",
                        password = "TestPassword",
                        email = "dfraust4@students.kennesaw.edu",
                        firstName = "Diego",
                        lastName = "Frausto",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2003, 8, 30),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 1,
                        isActive = true
                    },
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "cKirkwood0924",
                        password = "PasswordTest",
                        email = "ckirkwoo@students.kennesaw.edu",
                        firstName = "Chris",
                        lastName = "Kirkwood",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2002, 10, 22),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 1,
                        isActive = true
                    },
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "rPowell0924",
                        password = "TestPassword",
                        email = "rpowel57@students.kennesaw.edu",
                        firstName = "Riley",
                        lastName = "Powell",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2001, 11, 23),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 1,
                        isActive = true
                    },
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "hNguyen0924",
                        password = "passwordTest",
                        email = "hnguy126@students.kennesaw.edu",
                        firstName = "Hong",
                        lastName = "Nguyen",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2001, 5, 23),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 1,
                        isActive = true
                    },
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "mAccount0924",
                        password = "ManagerPassword",
                        email = "manager@students.kennesaw.edu",
                        firstName = "Manager",
                        lastName = "Account",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2024, 9, 17),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 2,
                        isActive = true
                    },
                    new User
                    {
                        userId = Guid.NewGuid(),
                        username = "aAccount0924",
                        password = "AccountantPassword",
                        email = "accountant@students.kennesaw.edu",
                        firstName = "Accountant",
                        lastName = "Account",
                        address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2024, 9, 17),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 3,
                        isActive = true
                    });

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
