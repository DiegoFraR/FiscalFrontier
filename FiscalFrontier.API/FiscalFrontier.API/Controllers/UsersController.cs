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
            var lastTwoDigitsOfYear = DateTime.Now.Year % 100;
            var createdUserName = request.firstName[0] + request.lastName + DateTime.Now.Day + lastTwoDigitsOfYear;
            // Map DTO to Domain Model
            var user = new User
            {
                UserName = createdUserName,
                Password = request.password,
                Email = request.email,
                FirstName = request.firstName,
                LastName = request.lastName,
                CreatedDate = DateTime.Now,
                PasswordExpirationDate = DateTime.Now.AddDays(60),
                RoleId = 3
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            // Domain Model to DTO
            var userDTO = new UserDTO
            {
                userName = user.UserName
            };

            return Ok(userDTO);
        }
    }
}
