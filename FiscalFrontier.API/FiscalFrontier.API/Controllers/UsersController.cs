using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

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
        private readonly IConfiguration configuration;

        public UsersController(ApplicationDbContext dbContext, AuthDbContext authDbContext, UserManager<User> userManager, IConfiguration configuration) 
        {
            this.dbContext = dbContext;
            this.authDbContext = authDbContext;
            this.userManager = userManager;
            this.configuration = configuration;
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

                    var userDto = new UserDTO
                    {
                        userName = user.UserName
                    };

                    //Creates the User Security Questions
                    await CreateUserSecurityQuestions(user, request);

                    sendUserEmailVerification(user.firstName, user.lastName, user.Email, true);

                    return Ok(userDto);
                    
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

        [HttpGet]
        [Route("userRegistrationRequests")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCreateUserRequests()
        {
            var createUserRequests = await dbContext.UserCreationRequests.ToListAsync();

            return Ok(createUserRequests);
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

            
            sendUserEmailVerification(request.firstName, request.lastName,request.email, false);
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

        //GET: {apibaseurl}/api/users/{id}
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var userDto = new ShowUserDetailsDTO
            {
                userId = user.Id,
                username = user.UserName,
                email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                address = user.address,
                isActive = user.isActive,
            };

            return Ok(userDto);
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
                userId = user.Id,
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

            var userSecurityQuestions = await authDbContext.UserSecurityQuestions.FindAsync(id);
            
            if(userSecurityQuestions is not null)
            {
                authDbContext.UserSecurityQuestions.RemoveRange(userSecurityQuestions);
                await authDbContext.SaveChangesAsync();
            }

            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User Deleted" });

        }


        //Helper Methods (Makes code look cleaner)
        private string generateUserName(string firstName, string lastName)
        {
            var Year = DateTime.Now.Year % 100;
            var createdUserName = firstName[0] + lastName + DateTime.Now.Month + Year;

            var username = createdUserName.Replace(" ", "");
            return username;
        }

        
        private async Task<IActionResult> CreateUserSecurityQuestions(IdentityUser user, UserCreationRequest request)
        {
            var userSecurityQuestions = new List<UserSecurityQuestion>
            {
                new UserSecurityQuestion
                {
                    securityQuestionId = request.securityQuestion1Id,
                    userId = user.Id,
                    answer = request.securityQuestion1Answer
                },
                new UserSecurityQuestion
                {
                    securityQuestionId = request.securityQuestion2Id,
                    userId = user.Id,
                    answer = request.securityQuestion2Answer
                }
            };

            try
            {
                await authDbContext.UserSecurityQuestions.AddRangeAsync(userSecurityQuestions);
                await authDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            return NoContent();
        }


        private async void sendUserEmailVerification(string firstName, string lastName, string email, Boolean verified)
        {
            var sendGrid = "";
            var client = new SendGridClient(sendGrid);
            var from = new EmailAddress("fiscalfrontier4713@gmail.com", "Fiscal Frontier");
            var subject = "";
            var plainTextContent = "";
            var htmlContent = "";
            if (verified == false)
            {
                subject = "User Registration Denied";
                plainTextContent = "Your request for registration to the Fiscal Frontier Application has been denied.";
                htmlContent = "If you believe this is incorrect, please send an email to <strong>fiscalfrontier4713@gmail.com</strong>.";
            }
            else
            {
                subject = "User Registration Accepted";
                plainTextContent = "Your request for registration to the Fiscal Frontier Application has been approved.";
                htmlContent = "If you did not register for this service, please send an email to <strong>fiscalfrontier4713@gmail.com</strong> to stop receiving emails.";
            }
            var to = new EmailAddress(email, firstName + " " + lastName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
