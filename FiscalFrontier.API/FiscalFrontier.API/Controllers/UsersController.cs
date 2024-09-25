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

        //Creates User Request.
        [HttpPost("create")]
        
        public async Task<IActionResult> CreateUserRequest(CreateUserRequestDTO request)
        {
            var userCreationRequest = new UserCreationRequest
            {
                password = request.password,
                email = request.email,
                firstName = request.firstName,
                lastName = request.lastName,
                address = request.address,
                dateOfBirth = request.dateOfBirth,
                isApproved = false,
                securityQuestion1Id = request.securityQuestion1Id,
                securityQuestion1Answer = request.securityQuestion1Answer,
                securityQuestion2Id = request.securityQuestion2Id,
                securityQuestion2Answer = request.securityQuestion2Answer
            };

            await dbContext.UserCreationRequests.AddAsync(userCreationRequest);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "User Creation Request Submitted for Approval." });
        }

        //Approve User Creation Request
        [HttpPost("approve/{requestId}")]
        public async Task<IActionResult> ApproveUserRequest(int requestId)
        {
            var userCreationRequest = await dbContext.UserCreationRequests.FindAsync(requestId);

            if (userCreationRequest == null)
            {
                return NotFound("Request Not Found.");
            }

            if (!userCreationRequest.isApproved) {
                var lastTwoDigitsOfYear = DateTime.Now.Year % 100;
                var createdUserName = userCreationRequest.firstName[0] + userCreationRequest.lastName + DateTime.Now.Day + lastTwoDigitsOfYear;

                var user = new User
                {
                    username = createdUserName,
                    password = userCreationRequest.password,
                    email = userCreationRequest.email,
                    firstName = userCreationRequest.firstName,
                    lastName = userCreationRequest.lastName,
                    address = userCreationRequest.address,
                    dateOfBirth = userCreationRequest.dateOfBirth,
                    createdDate = DateTime.Now,
                    passwordExpirationDate = DateTime.Now.AddDays(60),
                    roleId = 3,
                    isActive = true
                };

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                var securityQuestions = new List<UserSecurityQuestion>()
                {
                    new UserSecurityQuestion
                    {
                        userId = user.userId,
                        securityQuestionId = userCreationRequest.securityQuestion1Id,
                        answer = userCreationRequest.securityQuestion1Answer
                    },
                    new UserSecurityQuestion
                    {
                        userId = user.userId,
                        securityQuestionId = userCreationRequest.securityQuestion2Id,
                        answer = userCreationRequest.securityQuestion2Answer
                    }
                };

                await dbContext.UserSecurityQuestions.AddRangeAsync(securityQuestions);
                await dbContext.SaveChangesAsync();

                var userDTO = new UserDTO
                {
                    userName = user.username
                };

                //Remove Request Entry from CreateUserRequest Table
                dbContext.UserCreationRequests.Remove(userCreationRequest);
                await dbContext.SaveChangesAsync();

                return Ok(userDTO);
            }

            return BadRequest("This request has already been processed.");
        }

        //Delete (Deny) User Creation Request
        [HttpDelete("deny/{requestId}")]
        public async Task<IActionResult> DeleteUserRequest(int requestId)
        {
            var userCreationRequest = await dbContext.UserCreationRequests.FindAsync(requestId);

            if(userCreationRequest == null)
            {
                return NotFound("Request Not Found in DB.");
            }

            dbContext.UserCreationRequests.Remove(userCreationRequest);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "User Creation Request has been deleted" });
        }

        //Deletes a User from the DB
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId) {
            var user = await dbContext.Users.FindAsync(userId);

            if (user == null) {
                return NotFound("User Not Found!");
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "User Deleted Successfully!" });
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

        //Modify Existing User
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUserById(Guid id, UpdateUserRequestDTO request)
        {

            var existingUser = await dbContext.FindAsync<User>(id);

            if (existingUser == null) {
                return NotFound("User not found.");
            }
            else
            {
                existingUser.username = request.username;
                existingUser.email = request.email;
                existingUser.firstName = request.firstName;
                existingUser.lastName = request.lastName;
                existingUser.address = request.address;
                existingUser.dateOfBirth = request.dateOfBirth;
                existingUser.roleId = request.roleId;
                existingUser.isActive = request.isActive;
                await dbContext.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
