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

            await InitializeRolesAsync(cancellationToken);

            var usersDelete = await _context.Users.ToListAsync();

            var securityQuestionsDelete = await _context.UserSecurityQuestions.ToListAsync();

            _context.Users.RemoveRange(usersDelete);
            _context.UserSecurityQuestions.RemoveRange(securityQuestionsDelete);

            await _context.SaveChangesAsync(cancellationToken);

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
                        address =  "1100 South Marietta Pkwy SE, Marietta, GA 30060",
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
                        address =  "1100 South Marietta Pkwy SE, Marietta, GA 30060",
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
                        address =  "1100 South Marietta Pkwy SE, Marietta, GA 30060",
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
                        address =  "1100 South Marietta Pkwy SE, Marietta, GA 30060",
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
                        address =  "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                        createdDate = DateTime.UtcNow,
                        dateOfBirth = new DateTime(2024, 9, 17),
                        passwordExpirationDate = DateTime.UtcNow.AddMonths(3),
                        roleId = 3,
                        isActive = true
                    }
                };

                    _context.Users.AddRange(users);
                    await _context.SaveChangesAsync(cancellationToken);

                //Creating Security Question for Generated Users
                var userIdList = users.Select(u => u.userId).ToList();
                var securityQuestions = new List<UserSecurityQuestion>
                {
                    new UserSecurityQuestion
                    {
                        userId = userIdList[0],
                        securityQuestionId = 1,
                        answer="Answer for Diego Security Question 1"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[0],
                        securityQuestionId = 2,
                        answer="Answer for Diego Security Question 2"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[1],
                        securityQuestionId = 3,
                        answer="Answer for Chris Security Question 3"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[1],
                        securityQuestionId = 4,
                        answer="Answer for Chris Security Question 4"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[2],
                        securityQuestionId = 1,
                        answer="Answer for Riley Security Question 1"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[2],
                        securityQuestionId = 2,
                        answer="Answer for Riley Security Question 2"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[3],
                        securityQuestionId = 3,
                        answer="Answer for Hong Security Question 3"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[3],
                        securityQuestionId = 4,
                        answer="Answer for Hong Security Question 4"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[4],
                        securityQuestionId = 1,
                        answer="Answer for Manager Security Question 1"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[4],
                        securityQuestionId = 2,
                        answer="Answer for Manager Security Question 2"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[5],
                        securityQuestionId = 3,
                        answer="Answer for Accountant Security Question 3"
                    },
                    new UserSecurityQuestion
                    {
                        userId = userIdList[5],
                        securityQuestionId = 4,
                        answer="Answer for Accountant Security Question 4"
                    }
                };

                await _context.UserSecurityQuestions.AddRangeAsync(securityQuestions);
                await _context.SaveChangesAsync(cancellationToken);

            }
        }

        public async Task InitializeRolesAsync(CancellationToken cancellationToken = default)
        {
            if (!_context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { roleName = "Administrator" },
                    new Role { roleName = "Manager" },
                    new Role { roleName = "Accountant" }
                };

                await _context.Roles.AddRangeAsync(roles);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
