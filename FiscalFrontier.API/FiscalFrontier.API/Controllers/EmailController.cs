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
        public async Task<IActionResult> SendEmailAsync(string subject, string message, string emailRecepient)
        {
            var userTo = await userManager.FindByEmailAsync(emailRecepient);

            if (userTo == null) 
            {
                ModelState.AddModelError("userEmail", $"User associated with {emailRecepient} not found!");
                return BadRequest(ModelState);  
            }

            try
            {
                var sendGridKey = "";
                var client = new SendGridClient(sendGridKey);
                var from = new EmailAddress("fiscalfrontier4713@gmail.com", "Fiscal Frontier");
                var to = new EmailAddress(userTo.Email, userTo.firstName + " " + userTo.lastName);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, message, null);
                var response = await client.SendEmailAsync(msg);

                if (!response.IsSuccessStatusCode) 
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    ModelState.AddModelError("sendGrid", $"Failed to send email: {responseBody}");
                    return BadRequest(ModelState);
                }

                return Ok(new { message = "Email sent successfully." });
            } catch (Exception ex) 
            { 
                ModelState.AddModelError("ex", $"{ex.Message}");
                return BadRequest(ModelState);
            }
        }
    }
}
