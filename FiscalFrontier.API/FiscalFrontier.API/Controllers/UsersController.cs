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

        //Creates Users.
        [HttpPost]
        public async Task<IActionResult> CreateUserRequest(CreateUserRequestDTO request)
        {
            var lastTwoDigitsOfYear = DateTime.Now.Year % 100;
            var createdUserName = request.firstName[0] + request.lastName + DateTime.Now.Day + lastTwoDigitsOfYear;
            // Map DTO to Domain Model
            var user = new User
            {
                username = createdUserName,
                password = request.password,
                email = request.email,
                firstName = request.firstName,
                lastName = request.lastName,
                address = request.address,
                dateOfBirth = request.dateOfBirth,
                createdDate = DateTime.Now,
                passwordExpirationDate = DateTime.Now.AddDays(60),
                roleId = 3,
                isActive = true
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var securityQuestions = new List<UserSecurityQuestion>
            {
                new UserSecurityQuestion
                {
                    userId = user.userId,
                    securityQuestionId = request.securityQuestion1Id,
                    answer = request.securityQuestion1Answer
                },
                new UserSecurityQuestion
                {
                    userId= user.userId,
                    securityQuestionId= request.securityQuestion2Id,
                    answer = request.securityQuestion2Answer
                }
            };

            await dbContext.UserSecurityQuestions.AddRangeAsync(securityQuestions);
            await dbContext.SaveChangesAsync();

            // Domain Model to DTO
            var userDTO = new UserDTO
            {
                userName = user.username
            };

            return Ok(userDTO);
        }
        
        //Returns all the users in the database. 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowUserDetailsDTO>>> GetUsers()
        {
            var users = await dbContext.Users.ToListAsync();

            var userDtos = users.Select(user => new ShowUserDetailsDTO
            {
                username = user.username,
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                roleId = user.roleId
            }).ToList();

            return Ok(userDtos);
        }
    }
}
