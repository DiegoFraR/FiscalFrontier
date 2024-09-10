using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    // https://localhost:xxxx/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateUserRequestDTO request)
        {
            var userRole = await dbContext.Roles
                .FirstOrDefaultAsync(r => r.roleName == "Accountant");
            var createdUserName = request.firstName[0] + request.lastName;
            // Map DTO to Domain Model
            var user = new User
            {
                Id = Guid.NewGuid(),
                userName = createdUserName,
                passwordHash = request.password,
                email = request.email,
                firstName = request.firstName,
                lastName = request.lastName,
                CreatedDate = DateTime.Now,
                PasswordExpirationDate = DateTime.Now.AddDays(60),
                Role = userRole,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            // Domain Model to DTO
            var userDTO = new UserDTO
            {
                userName = user.userName
            };

            return Ok(userDTO);
        }
    }
}
