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


            // Create Admin User
            var admin = new User()
            {
                //Custom User Items
                Id = Guid.NewGuid().ToString(),
                UserName = "AAccount0924",
                Email = "adminAccount@gmail.com",
                NormalizedEmail = "adminAccount@gmail.com".ToUpper(),
                firstName = "Admin",
                lastName = "SAccount",
                address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                createdDate = DateTime.UtcNow,
                dateOfBirth = new DateTime(2003, 8, 30),
                passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                isActive = true,
            };

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

            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Admin@123");
            manager.PasswordHash = new PasswordHasher<User>().HashPassword(manager, "Manager@123");
            accountant.PasswordHash = new PasswordHasher<User>().HashPassword(accountant, "Accountant@123");

            builder.Entity<User>().HasData(admin);
            builder.Entity<User>().HasData(manager);
            builder.Entity<User>().HasData(accountant);

            // Give Roles To Admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = admin.Id,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = admin.Id,
                    RoleId = managerRoleId
                },
                new()
                {
                    UserId = admin.Id,
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
        }
    }
}
