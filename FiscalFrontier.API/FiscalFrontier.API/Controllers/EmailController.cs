using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public EmailController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailToGivenRole(SendEmailDto sendEmailDto)
        {
            var users = userManager.Users.ToList();

            var roleEmails = new List<string>();

            foreach (var user in users) 
            {
                var roles = await userManager.GetRolesAsync(user);
                if(roles.Contains(sendEmailDto.Role))
                {
                    roleEmails.Add(user.Email);
                }
            }

            foreach (var email in roleEmails)
            {
                var sendGridApiKey = "";
                var client = new SendGridClient(sendGridApiKey);
                var from = new EmailAddress("fiscalfrontier4713@gmail.com", "Fiscal Frontier");
                var to = new EmailAddress(email);
                var msg = MailHelper.CreateSingleEmail(from, to, sendEmailDto.Subject, sendEmailDto.Message, sendEmailDto.Message);

                var response = await client.SendEmailAsync(msg);

                if (!response.IsSuccessStatusCode) 
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    ModelState.AddModelError("sendGrid", $"Failed to send email: {responseBody}");
                    return BadRequest(ModelState);
                }
            }

            return Ok(new { message = "Emails sent successfully." });
        }
    }
}
