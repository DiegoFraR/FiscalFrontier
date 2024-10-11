using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
=======
using FiscalFrontier.API.Services.Interfaces;
>>>>>>> ea95ad4dbf4fb7773341a6c5b09362ae4ef75c37
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
<<<<<<< HEAD
        public ChartOfAccountController(ApplicationDbContext dbContext, UserManager<User> userManager)
=======
        private readonly IAccountNumberGenerator accountNumberGenerator;

        public ChartOfAccountController(ApplicationDbContext dbContext, IAccountNumberGenerator accountNumberGenerator)
>>>>>>> ea95ad4dbf4fb7773341a6c5b09362ae4ef75c37
        {
            this.dbContext = dbContext;
            this.accountNumberGenerator = accountNumberGenerator;
        }

        //Creates a Chart Of Account 
        [HttpPost]
        [Route("/create/{userId}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateChartOfAccount([FromBody] CreateChartOfAccountDto request, Guid userId)
        {
            
            if(await dbContext.ChartOfAccounts.AnyAsync(a => a.accountName == request.accountName))
            {
                return new BadRequestObjectResult("An account with this name already exists!");
            }

            var chartOfAccountCreationRequest = new ChartOfAccount
            {
                accountName = request.accountName,
                accountNumber = accountNumberGenerator.GenerateAccountNumber(request.accountCategory),
                accountDescription = request.accountDescription,
                accountNormalSide = setNormalSide(request.accountCategory),
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
                accountComment = request.accountComment,
                accountActive = true
            };

            await dbContext.ChartOfAccounts.AddAsync(chartOfAccountCreationRequest);

            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Created Chart Of Account " + chartOfAccountCreationRequest.accountName});
        }

        //Update a Chart of Account
        [HttpPut]
        [Route("modify/{accountId}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ModifyChartOfAccount(int accountId, [FromBody] UpdateChartOfAccountDto request)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(accountId);

            var changes = new List<string>();

            if (chartOfAccount == null) 
            {
                return NotFound($"Account with ID {accountId} not found.");

            }

            if(request.accountName != null && !await dbContext.ChartOfAccounts.AnyAsync(a => a.accountName == request.accountName))
            {
                changes.Add($"Changed Account Name from {chartOfAccount.accountName} to {request.accountName}.");
                chartOfAccount.accountName = request.accountName.Trim();
            }
            

            if (request.accountDescription != null && (request.accountDescription != chartOfAccount.accountDescription)) 
            {
                changes.Add($"Changed Account Description from {chartOfAccount.accountDescription} to {request.accountDescription}.");
                chartOfAccount.accountDescription = request.accountDescription.Trim();
            }

            if (request.accountCategory != null && (request.accountCategory != chartOfAccount.accountCategory))
            {
                var normalSide = chartOfAccount.accountNormalSide;
                var accountNumber = chartOfAccount.accountNumber;
                changes.Add($"Changed Account Category from {chartOfAccount.accountCategory} to {request.accountCategory}.");
                chartOfAccount.accountCategory = request.accountCategory;
                chartOfAccount.accountNormalSide = setNormalSide(chartOfAccount.accountCategory);
                if(chartOfAccount.accountNormalSide != normalSide)
                {
                    changes.Add($"Changed Account Normal Side from {normalSide} to {chartOfAccount.accountNormalSide}");
                }
                chartOfAccount.accountNumber = accountNumberGenerator.GenerateAccountNumber(request.accountCategory);

                changes.Add($"Changed Account Number from {accountNumber} to {chartOfAccount.accountNumber}");
            }

            if((chartOfAccount.accountBalance == 0) && (chartOfAccount.accountActive != request.accountActive))
            {
                changes.Add($"Changed Account Active Status from {chartOfAccount.accountActive} to {request.accountActive}.");
                chartOfAccount.accountActive = request.accountActive;
            }

            if (changes.Count > 0)
            {
                var updateHistory = new AccountUpdateHistory
                {
                    accountId = chartOfAccount.accountId,
                    updateDate = DateTime.UtcNow,
                    changes = string.Join("; ", changes)
                };

                dbContext.AccountUpdatesHistories.Add(updateHistory);
            }


            return Ok(new { Message = "Account has been updated!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetChartOfAccounts()
        {
            var chartOfAccounts = await dbContext.ChartOfAccounts.ToListAsync();

            var chartOfAccountDtos = chartOfAccounts.Select(account => new ShowAllChartOfAccountsDTO
            {
                accountNumber = account.accountNumber,
                accountDescription = account.accountDescription,
                accountCategory = account.accountCategory,
                accountSubcategory = account.accountSubcategory,
                accountBalance = account.accountBalance,
                accountComment = account.accountComment,
                accountActive = account.accountActive
            }).ToList();

            return Ok(chartOfAccountDtos);
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(accountId);

            if (chartOfAccount == null) 
            {
                return NotFound("Account Not Found!");
            }

            var chartOfAccountDTO = new ShowChartOfAccountDetailedDTO
            {
                accountName = chartOfAccount.accountName,
                accountNumber = chartOfAccount.accountNumber,
                accountDescription = chartOfAccount.accountDescription,
                accountNormalSide = chartOfAccount.accountNormalSide,
                accountCategory = chartOfAccount.accountCategory,
                accountSubcategory = chartOfAccount.accountSubcategory,
                accountInitialBalance = chartOfAccount.accountInitialBalance,
                accountDebit = chartOfAccount.accountDebit,
                accountCredit = chartOfAccount.accountCredit,
                accountBalance = chartOfAccount.accountBalance,
                accountDateTimeAdded = chartOfAccount.accountDateTimeAdded,
                accountUserId = chartOfAccount.accountUserId,
                accountOrder = chartOfAccount.accountOrder,
                accountStatement = chartOfAccount.accountStatement,
                accountComment = chartOfAccount.accountComment,
                accountActive = chartOfAccount.accountActive
            };

            return Ok(chartOfAccountDTO);
        }

        [HttpGet]
        [Route("{accountId}/changes")]
        public async Task<IActionResult> GetAccountChangeHistory(int accountId)
        {
            var updates = await dbContext.AccountUpdatesHistories
                .Where(u => u.accountId == accountId)
                .ToListAsync();
            if(updates == null)
            {
                return NotFound($"No Updates have been made to Account {accountId}");
            }

            var updatesDTO = updates.Select(u => new AccountUpdateHistoryDTO
            {
                changes = u.changes,
                updateDate = u.updateDate
            });

            return Ok(updatesDTO);
        }


        //Helper Methods

        //Sets the Normal Side based on the Account Category
        private string setNormalSide(string accountCategory)
        {
            switch(accountCategory)
            {
                case "Asset":
                    return "Debit";
                case "Liability":
                    return "Credit";
                case "Equity":
                    return "Credit";
                case "Expense":
                    return "Debit";
                case "Revenue":
                    return "Credit";
                default:
                    throw new Exception("Account Category Invalid!");
            }
        }

        //Creates a Chart Of Account 
        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> GetCreateChartOfAccountById([FromBody] ChartOfAccount request, Guid userId)
        {

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
