using FiscalFrontier.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seeding Security Questions
            builder.Entity<SecurityQuestions>().HasData(
                new SecurityQuestions { securityQuestionId = 1, securityQuestion = "What was the first exam you failed?" },
                new SecurityQuestions { securityQuestionId = 2, securityQuestion = "What was your Mother/Father's first car brand?" },
                new SecurityQuestions { securityQuestionId = 3, securityQuestion = "What was the name of your siblings favorite stuffed animal?" },
                new SecurityQuestions { securityQuestionId = 4, securityQuestion = "In what city was your Grandmother or Grandfather born?" }
                );

            //Seeding Roles
            var adminRoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b";
            var managerRoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b";
            var accountantRoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9";

            // Create Admin, Manager, and Accountant Roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Id = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper(),
                    ConcurrencyStamp = managerRoleId
                },
                new IdentityRole()
                {
                    Id = accountantRoleId,
                    Name = "Accountant",
                    NormalizedName = "Accountant".ToUpper(),
                    ConcurrencyStamp = accountantRoleId
                }
            };
            // Seed the Roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Seeding 3 Users (One Admin, One Manager, One Accountant)
            // Create Admin User
            //Admin Users (Group Members)

            //Diego
            var diegoAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "DFrausto1024",
                Email = "dfraust4@students.kennesaw.edu",
                NormalizedEmail = "dfraust4@students.kennesaw.edu".ToUpper(),
                firstName = "Diego",
                lastName = "Frausto",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2003, 08, 30),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true
            };

            diegoAdmin.PasswordHash = new PasswordHasher<User>().HashPassword(diegoAdmin, "Diego@123");

            //Chris 
            var chrisAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "CKirkwood1024",
                Email = "ckirkwoo@students.kennesaw.edu",
                NormalizedEmail = "ckirkwoo@students.kennesaw.edu".ToUpper(),
                firstName = "Chris",
                lastName = "Kirkwood",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2002, 04, 24),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true
            };

            chrisAdmin.PasswordHash = new PasswordHasher<User>().HashPassword(chrisAdmin, "Chris@123");

            //Riley
            var rileyAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "RPowell1024",
                Email = "rpowel57@students.kennesaw.edu",
                NormalizedEmail = "rpowel57@students.kennesaw.edu".ToUpper(),
                firstName = "Riley",
                lastName = "Powell",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2002, 07, 21),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true
            };

            rileyAdmin.PasswordHash = new PasswordHasher<User>().HashPassword(rileyAdmin, "Riley@123");

            //Hong
            var hongAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "HNguyen1024",
                Email = "hnguy126@students.kennesaw.edu",
                NormalizedEmail = "hnguy126@students.kennesaw.edu".ToUpper(),
                firstName = "Hong",
                lastName = "Nguyen",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2003, 01, 30),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true
            };

            hongAdmin.PasswordHash = new PasswordHasher<User>().HashPassword(hongAdmin, "Hong@123");

            //Create Manager User
            var manager = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "MAccount0924",
                Email = "managerAccount@gmail.com",
                NormalizedEmail = "managerAccount@gmail.com".ToUpper(),
                firstName = "Manager",
                lastName = "Account",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2003, 8, 30),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true,
            };

            //Create Accountant User
            var accountant = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "AAccount0824",
                Email = "accountantAccount@gmail.com",
                NormalizedEmail = "accountantAccount@gmail.com".ToUpper(),
                firstName = "Accountant",
                lastName = "Account",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2003, 8, 30),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true,
            };

            manager.PasswordHash = new PasswordHasher<User>().HashPassword(manager, "Manager@123");
            accountant.PasswordHash = new PasswordHasher<User>().HashPassword(accountant, "Accountant@123");

            builder.Entity<User>().HasData(diegoAdmin);
            builder.Entity<User>().HasData(chrisAdmin);
            builder.Entity<User>().HasData(rileyAdmin);
            builder.Entity<User>().HasData(hongAdmin);
            builder.Entity<User>().HasData(manager);
            builder.Entity<User>().HasData(accountant);

            // Give Roles To Admins
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                //Diego's Roles
                new()
                {
                    UserId = diegoAdmin.Id,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = diegoAdmin.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = diegoAdmin.Id,
                    RoleId = accountantRoleId
                },
                //Chris's Roles
                new()
                {
                    UserId = chrisAdmin.Id,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = chrisAdmin.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = chrisAdmin.Id,
                    RoleId = accountantRoleId
                },
                //Riley's Roles
                new()
                {
                    UserId = rileyAdmin.Id,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = rileyAdmin.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = rileyAdmin.Id,
                    RoleId = accountantRoleId
                },
                //Hong's Roles
                new()
                {
                    UserId = hongAdmin.Id,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = hongAdmin.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = hongAdmin.Id,
                    RoleId = accountantRoleId
                }
            };

            //Give Roles to Manager
            var managerRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = manager.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = manager.Id,
                    RoleId = accountantRoleId
                }
            };

            //Give Role to Accountant
            var accountantRole = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = accountant.Id,
                    RoleId = managerRoleId
                }
            };

            //Seed Admin Roles 
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
            builder.Entity<IdentityUserRole<string>>().HasData(managerRoles);
            builder.Entity<IdentityUserRole<string>>().HasData(accountantRole);

            builder.Entity<UserSecurityQuestion>().HasData(
                //Diego's Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 1,
                    userId = diegoAdmin.Id,
                    securityQuestionId = 1,
                    answer = "Accounting 101"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 2,
                    userId = diegoAdmin.Id,
                    securityQuestionId = 2,
                    answer = "Porsche"
                },
                //Chris's Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 3,
                    userId = chrisAdmin.Id,
                    securityQuestionId = 1,
                    answer = "Accounting 101"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 4,
                    userId = chrisAdmin.Id,
                    securityQuestionId = 2,
                    answer = "Porsche"
                },
                //Riley's Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 5,
                    userId = rileyAdmin.Id,
                    securityQuestionId = 1,
                    answer = "Accounting 101"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 6,
                    userId = rileyAdmin.Id,
                    securityQuestionId = 2,
                    answer = "Porsche"
                },
                //Hong's Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 7,
                    userId = hongAdmin.Id,
                    securityQuestionId = 1,
                    answer = "Accounting 101"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 8,
                    userId = hongAdmin.Id,
                    securityQuestionId = 2,
                    answer = "Porsche"
                },
                //Manager Account Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 9,
                    userId = manager.Id,
                    securityQuestionId = 3,
                    answer = "Clifford the Big Red Dog"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 10,
                    userId = manager.Id,
                    securityQuestionId = 4,
                    answer = "Marietta, Georgia"
                },
                //Accountant Account Security Questions
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 11,
                    userId = accountant.Id,
                    securityQuestionId = 1,
                    answer = "Nissan"
                },
                new UserSecurityQuestion
                {
                    userSecurityQuestionId = 12,
                    userId = accountant.Id,
                    securityQuestionId = 4,
                    answer = "Atlanta, Georgia"
                });
        }
    }
}
