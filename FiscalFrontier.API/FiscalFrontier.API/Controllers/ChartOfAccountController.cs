using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        public ChartOfAccountController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        //Creates a Chart Of Account 
        [HttpPost]
        [Route("/get/{userId}")]
        public async Task<IActionResult> CreateChartOfAccount([FromBody] CreateChartOfAccountDto request, Guid userId)
        {
            var chartOfAccountCreationRequest = new ChartOfAccount
            {
                accountName = request.accountName,
                accountNumber = request.accountNumber,
                accountDescription = request.accountDescription,
                accountNormalSide = request.accountNormalSide,
                accountCategory = request.accountCategory,
                accountSubcategory = request.accountSubcategory,
                accountInitialBalance = request.accountInitialBalance,
                accountDebit = request.accountDebit,
                accountCredit = request.accountCredit,
                accountBalance = request.accountInitialBalance - request.accountDebit - request.accountCredit,
                accountDateTimeAdded = DateTime.Now,
                accountUserId = userId,
                accountOrder = request.accountOrder,
                accountStatement = request.accountStatement,
                accountComment = request.accountComment
            };

            await dbContext.ChartOfAccounts.AddAsync(chartOfAccountCreationRequest);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Created Chart Of Account " + chartOfAccountCreationRequest.accountName});

        }

        //Creates a Chart Of Account 
        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "Accountant,Manager")]
        public async Task<IActionResult> GetCreateChartOfAccountById([FromBody] ChartOfAccount request, Guid userId)
        {
            var id = userId.ToString();
            var user = await userManager.FindByIdAsync(id);

            var chartOfAccountGetRequest = new ChartOfAccount
            {
                accountName = request.accountName,
                accountNumber = request.accountNumber,
                accountDescription = request.accountDescription,
                accountNormalSide = request.accountNormalSide,
                accountCategory = request.accountCategory,
                accountSubcategory = request.accountSubcategory,
                accountInitialBalance = request.accountInitialBalance,
                accountDebit = request.accountDebit,
                accountCredit = request.accountCredit,
                accountBalance = request.accountInitialBalance - request.accountDebit - request.accountCredit,
                accountDateTimeAdded = DateTime.Now,
                accountUserId = userId,
                accountOrder = request.accountOrder,
                accountStatement = request.accountStatement,
                accountComment = request.accountComment
            };

            return Ok(chartOfAccountGetRequest);

        }
    }
}
