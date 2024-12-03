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
                        userId = identityUser.Id,
                        roles = roles.ToList(),
                        token = jwtToken
                    };

                    return Ok(response);
                }
            }

            return NotFound(dbContext.ErrorMessages.Find(16));
        }

        [HttpGet]
        public async Task<IActionResult> GetSecurityQuestions()
        {
            var securityQuestions = await authDbContext.SecurityQuestions.ToListAsync();

            return Ok(securityQuestions);
        }

        [HttpGet]
        [Route("/userSecurityQuestions/{email}")]
        public async Task<ActionResult<UserSecurityQuestionDto>> GetUserSecurityQuestions(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return NotFound(dbContext.ErrorMessages.Find(17));
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

            if (userSecurityQuestions.Count == 0)
            {
                return NotFound(dbContext.ErrorMessages.Find(20));
            }

            return Ok(userSecurityQuestions);

        }

        [HttpPost]
        [Route("/userSecurityQuestions/Validate")]
        public async Task<IActionResult> CheckUserSecurityQuestionAnswers(SecurityQuestionAnswerDto answers)
        {
            var user = await userManager.FindByEmailAsync(answers.UserEmail);

            if (user is null)
            {
                return NotFound(dbContext.ErrorMessages.Find(17));
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

            var userSecurityQuestionAnswers = await authDbContext.UserSecurityQuestions
                .Where(u => u.userId == userId)
                .Select(u => new UserSecurityAnswersDto
                {
                    AnswerOne = u.answer,
                })
                .ToListAsync();

            if (userSecurityQuestionAnswers[0].AnswerOne == answers.AnswerOne && userSecurityQuestionAnswers[1].AnswerOne == answers.AnswerTwo)
            {
                return Ok(true);
            }

            return Ok(false);

        }

        [HttpPatch]
        [Route("/resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPassword)
        {
            var user = await userManager.FindByEmailAsync(resetPassword.UserEmail);

            if (user is null)
            {
                return NotFound(dbContext.ErrorMessages.Find(17));
            }

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, resetPassword.NewPassword);

            await userManager.UpdateAsync(user);

            return Ok();


        }
    }
}
