using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using FiscalFrontier.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<User> userManager, ApplicationDbContext dbContext, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.tokenRepository = tokenRepository;
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
    }
}
