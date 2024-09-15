using FiscalFrontier.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FiscalFrontier.API.Data
{
    public class DataInitializer
    {

        private readonly ApplicationDbContext _context;
        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            await _context.Database.EnsureCreatedAsync();

            if (_context.Users.Any())
            {
                return;
            }
            else
            {
                    var users = new List<User>
                {
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "dFrausto0924",
                        Password = "TestPassword",
                        Email = "dfraust4@students.kennesaw.edu",
                        FirstName = "Diego",
                        LastName = "Frausto",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 1
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "cKirkwood0924",
                        Password = "PasswordTest",
                        Email = "ckirkwoo@students.kennesaw.edu",
                        FirstName = "Chris",
                        LastName = "Kirkwood",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 1
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "rPowell0924",
                        Password = "TestPassword",
                        Email = "rpowel57@students.kennesaw.edu",
                        FirstName = "Riley",
                        LastName = "Powell",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 1
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "hNguyen0924",
                        Password = "passwordTest",
                        Email = "hnguy126@students.kennesaw.edu",
                        FirstName = "Hong",
                        LastName = "Nguyen",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 1
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "mAccount0924",
                        Password = "ManagerPassword",
                        Email = "manager@students.kennesaw.edu",
                        FirstName = "Manager",
                        LastName = "Account",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 2
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "aAccount0924",
                        Password = "AccountantPassword",
                        Email = "accountant@students.kennesaw.edu",
                        FirstName = "Accountant",
                        LastName = "Account",
                        CreatedDate = DateTime.UtcNow,
                        PasswordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        RoleId = 3
                    }
                };

                    _context.Users.AddRange(users);
                    await _context.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
