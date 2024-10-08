using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using FiscalFrontier.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly ITokenRepository tokenRepository;
        private readonly AuthDbContext authDbContext;

        public AuthController(UserManager<User> userManager, ApplicationDbContext dbContext, ITokenRepository tokenRepository, AuthDbContext authDbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.tokenRepository = tokenRepository;
            this.authDbContext = authDbContext;
        }

        // POST: {apibaseurl}/api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO request)
        {
            //Checks if Email exists. Need to modify this to username
            var identityUser = await userManager.FindByEmailAsync(request.email);

            if (identityUser is not null)
            {
                // Check Password
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    // Create a Token & Response
                    var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());

                    var response = new LoginResponseDTO()
                    {
                        email = request.email,
                        username = identityUser.UserName,
                        roles = roles.ToList(),
                        token = jwtToken
                    };

                    return Ok(response);
                }
            }
            ModelState.AddModelError("", "Email or Password is Incorrect.");

            return ValidationProblem(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetSecurityQuestions()
        {
            var securityQuestions = await authDbContext.SecurityQuestions.ToListAsync();

            return Ok(securityQuestions);
        }

        [HttpGet]
        [Route("/userSecurityQuestions/{email}")]
        public async Task <ActionResult<UserSecurityQuestionDto>> GetUserSecurityQuestions(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return NotFound("User Not Found!");
            }
            
            var userId = user.Id;

            var userSecurityQuestions = await authDbContext.UserSecurityQuestions
                .Where(u => u.userId == userId)
                .Include(u => u.securityQuestion)
                .Select(u => new UserSecurityQuestionDto
                {
                    securityQuestionChosen = u.securityQuestion.securityQuestion
                })
                .ToListAsync();

            if(userSecurityQuestions.Count == 0)
            {
                return NotFound("User Security Questions not found. Please contact our support team @ fiscalfrontier4713@gmail.com");
            }

            return Ok(userSecurityQuestions);
                
        }
    }
}
