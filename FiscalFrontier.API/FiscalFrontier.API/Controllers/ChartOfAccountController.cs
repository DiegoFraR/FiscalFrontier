using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ChartOfAccountController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Creates a Chart Of Account 
        [HttpPost]
        [Route("/create/{userId}")]
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
    }
}
