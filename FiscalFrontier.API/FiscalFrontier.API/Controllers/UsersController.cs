using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<User> userManager;

        public UsersController(ApplicationDbContext dbContext, AuthDbContext authDbContext, UserManager<User> userManager) 
        {
            this.dbContext = dbContext;
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        //Creates a request to generate a new user (MUST BE ACCEPTED BY ADMIN LATER).
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserRequest([FromBody] CreateUserRequestDTO request)
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

        //POST: {apibaseurl}/api/users/register/{id}
        //Approves User Creation.
        [HttpPost]
        [Route("register/{id}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> ApproveUserRegistration(int id)
        {
            var request = await dbContext.UserCreationRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound("Request For Registration Not Found!");
            }

            var generatedUserName = generateUserName(request.firstName, request.lastName);
            //Create Identity User Object
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = generatedUserName,
                Email = request.email.Trim(),
                firstName = request.firstName,
                lastName = request.lastName,
                address = request.address,
                isActive = true,
                dateOfBirth = request.dateOfBirth,
                createdDate = DateTime.Now,
                passwordExpirationDate = DateTime.Now.AddMonths(3),
            };

            //Create User
            var identityResult = await userManager.CreateAsync(user, request.password);

            if (identityResult.Succeeded)
            {
                // Add Accountant Role to User
                identityResult = await userManager.AddToRoleAsync(user, "Accountant");

                if (identityResult.Succeeded)
                {
                    dbContext.UserCreationRequests.Remove(request);
                    await dbContext.SaveChangesAsync();

                    //AddUserSecurityQuestions(user, request);

                    return Ok("User Created Successfully");
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }

        // DELETE: {apibaseurl}/api/users/register/{id}
        //Denies a User Registration Request
        [HttpDelete]
        [Route("register/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DenyUserRegistration(int id)
        {
            var request = await dbContext.UserCreationRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound("User Request Not Found.");
            }

            dbContext.UserCreationRequests.Remove(request);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "User Creation Request Denied." });
        }


        //PUT: {apibaseurl}/api/users/modify/{id}
        //Modifies Existing Users.
        [HttpPut]
        [Route("modify/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ModifyUsers(string id, [FromBody] UpdateUserRequestDTO request)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User Not Found");
            }

            user.Email = request.email.Trim();
            user.firstName = request.firstName.Trim();
            user.lastName = request.lastName.Trim();
            user.address = request.address.Trim();
            user.isActive = request.isActive;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest("Error Occured");
            }

            return Ok(new { Message = "User has been Updated" });
        }

        //GET: {apibaseurl}/api/users
        //Returns all the users in the database. 
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<ShowUserDetailsDTO>>> GetUsers()
        {
            var users = await authDbContext.Users.Cast<User>().ToListAsync();

            var userDtos = users.Select(user => new ShowUserDetailsDTO
            {
                username = user.UserName,
                email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                address = user.address,
                isActive = user.isActive,

            }).ToList();

            return Ok(userDtos);
        }

        //DELETE: {apibaseurl}/api/users/delete/{id}
        //Deletes a User from the DB
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user is null)
            {
                return NotFound("User Not Found.");
            }

            var result = await userManager.DeleteAsync(user);

            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User Deleted" });

        }


        //Helper Methods (Makes code look cleaner)
        private string generateUserName(string firstName, string lastName)
        {
            var Year = DateTime.Now.Year & 100;
            var createdUserName = firstName[0] + lastName + DateTime.Now.Month + Year;
            return createdUserName;
        }

        /*
        private async void AddUserSecurityQuestions(IdentityUser user, UserCreationRequest request)
        {
            var securityQuestions = new List<UserSecurityQuestion>
            {
                new UserSecurityQuestion
                {
                    securityQuestionId = request.securityQuestion1Id,
                    answer = request.securityQuestion1Answer,
                    userId = user.Id
                },
                new UserSecurityQuestion
                {
                    securityQuestionId = request.securityQuestion2Id,
                    answer = request.securityQuestion2Answer,
                    userId = user.Id,
                }
            };

            await dbContext.UserSecurityQuestions.AddRangeAsync(securityQuestions);
            await dbContext.SaveChangesAsync();
        }*/
    }
}
